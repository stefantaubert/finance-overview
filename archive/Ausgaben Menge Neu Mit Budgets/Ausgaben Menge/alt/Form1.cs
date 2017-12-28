using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<Ausgabe> _ausgaben = new List<Ausgabe>();
        DateSorter _ds = new DateSorter();
        string _file = Application.StartupPath + "\\saves.xml";
        public Form1()
        {
            InitializeComponent();
            Lade();
            ShowItems(listView1);
            if (comboBox3.Items.Count > 1) comboBox3.SelectedIndex = 1;
        }

        private void Save()
        {
            XmlSerialisierung<List<Ausgabe>>.Serialisieren(_ausgaben, _file);
        }
        private void Lade()
        {
            if (!File.Exists(_file)) return;
            _ausgaben = XmlSerialisierung<List<Ausgabe>>.Deserialisieren(_file);
            _ds.Sort(_ausgaben.ToArray());
            comboBox3.Items.Clear();
            foreach (var item in _ds.Monate)
                comboBox3.Items.Add(item);
            comboBox3.SelectedIndex = 0;
        }
        private List<Ausgabe> ConvertToList(Ausgabe[] array)
        {
            List<Ausgabe> ausg = new List<Ausgabe>();
            for (int i = 0; i < array.Length; i++)
                ausg.Add(array[i]);
            return ausg;
        }
        private void SetText(TextBox textBox)
        {
            string add;
            string text;
            if (textBox.Text.Length > 0)
            {
                add = textBox.Text.Substring(0, 1);
                text = textBox.Text.Substring(1, textBox.Text.Length - 1);
            }
            else return;
            if (add == "+" || add == "-") { errorProvider1.Clear(); } else { errorProvider1.SetError(textBox2, "Bitte geben Sie ein gültiges Vorzeichen ein! (+ / -)"); add = String.Empty; }
            string ausg = String.Empty;
            bool einKomma = false;
            foreach (var item in text)
                if (("1234567890,").Contains(Convert.ToString(item)))
                    if ((Convert.ToString(item) == ","))
                        if (!einKomma)
                        {
                            ausg += item;
                            einKomma = true;
                        }
                        else continue;
                    else
                        ausg += item;

            textBox.Text = add + ausg;
            textBox2.Select(textBox2.TextLength, 0);
        }
        private void ShowItems(ListView lw)
        {
            Ausgabe[] ausg = _ds.GetAusgaben(comboBox3.SelectedIndex);
            label4.Text = "Kontostand: " + _ds.Euros;
            lw.Items.Clear();
            for (int i = 0; i < ausg.Length; i++)
            {
                Ausgabe a = ausg[i];
                ListViewItem li = new ListViewItem();
                li.Text = a.Datum.ToShortDateString();
                li.SubItems.Add(a.Bezeichnung);
                li.SubItems.Add(a.Plus + a.Kosten.ToString() + " EUR");
                li.Tag = a;
                lw.Items.Add(li);
            }
            lw.Sort();
        }
        private void Add()
        {
            if (textBox1.Text.Trim() == String.Empty) { MessageBox.Show("Bitte geben Sie eine Bezeichnung ein!"); return; }
            if (textBox2.Text.Length < 2) { MessageBox.Show("Bitte geben Sie einen Betrag ein!"); return; }
            if (textBox2.Text.StartsWith("+") || textBox2.Text.StartsWith("-")) { } else { MessageBox.Show("Bitte setzten Sie eine Minus oder Plus vor den Betrag!"); return; }
            _ausgaben.Add(new Ausgabe());
            _ausgaben[_ausgaben.Count - 1].SetValue(textBox1.Text, textBox2.Text, Convert.ToDateTime(dateTimePicker1.Text));
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Text = DateTime.Now.ToString();
            _ds.Sort(_ausgaben.ToArray());
            ShowComboBoxItems();
        }
        private void Remove()
        {
            if (listView1.SelectedItems.Count != 0)
            {
                _ausgaben.Remove((Ausgabe)listView1.Items[listView1.SelectedItems[0].Index].Tag);
                _ds.Sort(_ausgaben.ToArray());
                ShowComboBoxItems();
            }
        }
        private void ShowComboBoxItems()
        {
            int index = comboBox3.SelectedIndex;
            comboBox3.Items.Clear();
            foreach (var item in _ds.Monate)
                comboBox3.Items.Add(item);
            if (comboBox3.SelectedIndex <= comboBox3.Items.Count && comboBox3.SelectedIndex != -1)
                comboBox3.SelectedIndex = index;
            else comboBox3.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SetText(textBox2);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox2.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }
        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowItems(listView1);
        }
    }
}
