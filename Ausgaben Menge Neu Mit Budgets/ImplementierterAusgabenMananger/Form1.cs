using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AusgabenManager;

namespace ImplementierterAusgabenMananger
{
    public partial class Form1 : Form
    {
        Verwaltung _v = new Verwaltung();

        public Form1()
        {
            InitializeComponent();
            listView1_SizeChanged(null, null);
            _v.Laden();
            LadePresets();
            LadeListViewEinträge();
        }

        private void LadePresets()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(_v.Presets.ToArray());
        }
        private void LadeListViewEinträge()
        {
            listView1.Items.Clear();
            for (int i = 0; i < _v.GefilterteEinträge.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                    _v.GefilterteEinträge[i].Datum.ToString("dd.MM.yy (ddd)"),
                    _v.GefilterteEinträge[i].Bezeichnung,
                    _v.GefilterteEinträge[i].Wert.ToString("0.00") + " " + Verwaltung.Währung })
                    {
                        ForeColor = Verwaltung.IsThisWeek(_v.GefilterteEinträge[i].Datum) ? Color.Blue : Color.Black,
                        Tag = _v.GefilterteEinträge[i].TmpInd
                    });
            }
            TextBoxFocus();
            listView1_SelectedIndexChanged(null, null);
        }
        private void TextBoxFocus()
        {
            comboBox1.Focus();
            comboBox1.Select(comboBox1.Text.Length, 0);
        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            listView1.Columns[1].Width = listView1.Width - listView1.Columns[0].Width - listView1.Columns[2].Width - 20;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxFocus();
            SendKeys.Send("{RIGHT}");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip1.Items[1].Visible = comboBox1.SelectedIndex != -1;
        }
        private void neuToolStripMenuItem_Click(object sender, EventArgs e) // Preset hinzufügen
        {
            _v.Presets.Add(comboBox1.Text.Trim());
            LadePresets();
        }
        private void löschenToolStripMenuItem_Click(object sender, EventArgs e) // Preset löschen
        {
            _v.Presets.RemoveAt(comboBox1.SelectedIndex);
            LadePresets();
            clearInputToolStripMenuItem_Click(null, null);
        }
        private void clearInputToolStripMenuItem_Click(object sender, EventArgs e) // Eingaben zurücksetzen
        {
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.Text = "";
            TextBoxFocus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Speichern
        {
            _v.Speichern();
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e) // TextBox focussieren
        {
            TextBoxFocus();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Finanzüberblick f;
            if (listView1.SelectedItems.Count <= 1)
                f = _v.Finanzblick();
            else
            {
                List<Transfer> tmp = new List<Transfer>();
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    tmp.Add(_v.Einträge[(int)listView1.SelectedItems[i].Tag]);
                }
                f = _v.Finanzblick(tmp);
            }
            finanzoverview1.Wert = f.AusgabenStr;
            finanzoverview2.Wert = f.EinnahmenStr;
            finanzoverview3.Wert = f.KontostandStr;
            finanzoverview4.Wert = f.ProzentVonVerwendetStr;
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip2.Items[0].Visible = listView1.SelectedItems.Count == 1;
            contextMenuStrip2.Items[1].Visible = listView1.SelectedItems.Count > 0;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e) // Ändern
        {
            Transfer t = _v.Einträge[(int)listView1.SelectedItems[0].Tag];
            dateTimePicker1.Value = t.Datum;
            comboBox1.Text = t.Wert + " " + t.Bezeichnung;
            toolStripMenuItem3_Click(null, null);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e) // Löschen
        {
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
                _v.EintragLöschen((int)(listView1.SelectedItems[listView1.SelectedItems.Count - 1 - i]).Tag);
            LadeListViewEinträge();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Control)
                {
                    _v.Filter = comboBox1.Text;
                    LadeListViewEinträge();
                    return;
                }
                if (_v.EintragHinzufügen(comboBox1.Text.Trim(), dateTimePicker1.Value))
                {
                    comboBox1.Text = "";
                    LadeListViewEinträge();
                }
                else TextBoxFocus();
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (_v.Filter != "")
            {
                _v.Filter = "";
                LadeListViewEinträge();
            }
        }
    }
}