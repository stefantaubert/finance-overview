using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        Cores _cr = new Cores();
        double Worth
        {
            get
            {
                textBox2.Text = Do.MakeOneKomma(textBox2.Text, false);
                double wert = 0;
                try
                {
                    wert = Convert.ToDouble(comboBox1.Text + textBox2.Text);
                }
                catch { }
                return wert;
            }
        }
        string Bezeichnung { get { return textBox1.Text.Trim(); } }

        public Form2()
        {
            InitializeComponent();
            this.Text += " - " + DateTime.Now.ToShortDateString();
            _cr.BudgetsChange += new Action<string[]>(_cr_BudgetsChange);
            if (_cr.Load())
            {
                if (_cr.Budgets.Count > 0)
                {
                    for (int i = 0; i < _cr.Budgets.Count; i++)
                    {
                        _cr.Budgets[i].ListViewChange += new Action<ListViewItem[]>(Form2_ListViewChange);
                        _cr.Budgets[i].MonateChange += new Action<string[]>(Form2_MonateChange);
                        _cr.Budgets[i].Presets.NamenChange += new Action<List<string>>(Presets_NamenChange);
                    }
                    if (_cr.SelectedBudgetIndex >= 0 && _cr.SelectedBudgetIndex < _cr.Budgets.Count)
                        cbBudgets.SelectedIndex = _cr.SelectedBudgetIndex;
                    else cbBudgets.SelectedIndex = 0;
                    comboBoxBudgetSIC(null, null);
                }
            }
            comboBox1.SelectedIndex = 0;
        }
        #region Other
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cr.SelectedBudgetIndex = cbBudgets.SelectedIndex;
            _cr.Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Add
            //if (cbBudgets.SelectedIndex == -1 || textBox2.Text == "") return;
            textBox2.Text = Do.MakeOneKomma(textBox2.Text, false);
            if (Bezeichnung == "" || Worth == 0) return;

            Transfer tr = new Transfer();
            tr.Bezeichnung = Bezeichnung;
            tr.Datum = dateTimePicker1.Value;
            tr.Wert = Worth;
            _cr.Budgets[cbBudgets.SelectedIndex].Add(tr);

            clearToolStripMenuItem_Click(clearToolP, new EventArgs());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
        }
        #endregion

        #region Budget
        private void _cr_BudgetsChange(string[] obj)
        {
            cbBudgets.Items.Clear();
            cbBudgets.Items.AddRange(obj);
            if (obj.Length <= 1)
                cbBudgets.SelectedIndex = obj.Length - 1;
            else
                cbBudgets.SelectedIndex = obj.Length - 2;

            textBox1.Focus();
            comboBoxBudgetSIC(cbBudgets, new EventArgs()); // wenn keins dann -1
        }
        private void comboBoxBudgetSIC(object sender, EventArgs e)
        {
            if (cbBudgets.SelectedIndex == -1) // wenn kein Budget vorhanden
            {
                löschenToolB.Visible =
                zurücksetzenToolB.Visible =
                ändernToolB.Visible =
                presetsToolP.Enabled =
                tabControl1.Enabled =
                listView1.Enabled =
                groupBox2.Enabled =
                false;

                textBox1.Text = textBox2.Text = "";
                cbPresets.Items.Clear();
                cbMonate.Items.Clear();
                cbBudgets.Items.Clear();
                userControlStatistik1.Actualisieren();
                userControlStatistik2.Actualisieren();
                userControlStatistik3.Actualisieren();
                comboBox1.SelectedIndex = 0;
                listView1.Items.Clear();
            }
            else
            {
                bool alles = cbBudgets.Items[cbBudgets.SelectedIndex].ToString() == Do.All;
                löschenToolB.Visible =
                zurücksetzenToolB.Visible =
                ändernToolB.Visible =
                presetsToolP.Enabled =
                contextMenuStrip1.Enabled =
                groupBox2.Enabled = !alles;
                if (alles) _cr.AddAllesBudget();
                tabControl1.Enabled = listView1.Enabled = true;

                cbPresets.Items.Clear();
                cbPresets.Items.AddRange(_cr.Budgets[cbBudgets.SelectedIndex].Presets.Namen.ToArray());
                // Form2_MonateChange(_cr.Budgets[cbBudgets.SelectedIndex].Monatsbezeichnungen.ToArray());
                _cr.Budgets[cbBudgets.SelectedIndex].MonateEvent();
            }
        }
        private void neu_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3(false);
            if (fm3.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Budget bdg = new Budget();
                bdg.Name = fm3.Bezeichnung;
                bdg.ListViewChange += new Action<ListViewItem[]>(Form2_ListViewChange);
                bdg.MonateChange += new Action<string[]>(Form2_MonateChange);
                bdg.Presets.NamenChange += new Action<List<string>>(Presets_NamenChange);
                _cr.AddBudget(bdg);
            }
        }
        private void löschen_Click(object sender, EventArgs e) { _cr.RemoveBudgetAt(cbBudgets.SelectedIndex); }
        private void zurücksetzen_Click(object sender, EventArgs e) { _cr.ResetBudget(cbBudgets.SelectedIndex); }
        private void ändern_Click(object sender, EventArgs e)
        {
            int tmpInd = cbBudgets.SelectedIndex;
            if (tmpInd == -1) return;
            Form3 fm3 = new Form3(cbBudgets.Text);
            if (fm3.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _cr.Change(cbBudgets.SelectedIndex, fm3.Bezeichnung);
                cbBudgets.SelectedIndex = tmpInd;
            }
        }
        #endregion

        #region Monate
        private void Form2_MonateChange(string[] obj)
        {
            cbMonate.Items.Clear();
            cbMonate.Items.AddRange(obj);
            cbMonate.SelectedIndex = cbMonate.Items.Count - 1;
            if (obj.Length == 0)
            {
                listView1.Items.Clear();
                //cbMonate.Enabled =
                tabControl1.Enabled =
                    listView1.Enabled =
                    false;
                userControlStatistik1.Actualisieren();
                userControlStatistik2.Actualisieren();
            }
            else
            {
                //cbMonate.Enabled =
                tabControl1.Enabled =
                     listView1.Enabled =
                    true;
            }
        }
        private void comboBoxMonate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonate.SelectedIndex != -1)
                Form2_ListViewChange(_cr.Budgets[cbBudgets.SelectedIndex].GetItems(cbMonate.SelectedIndex));
        }
        #endregion

        #region Presets
        // change adden

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Bezeichnung == "") return;
            _cr.Budgets[cbBudgets.SelectedIndex].Presets.Add(Bezeichnung, Worth);
            //cbPresets.SelectedIndex = ind;
            //comboBoxPresets_SelectedIndexChanged(comboBox1, new EventArgs());
        }

        private void ändernToolP_Click(object sender, EventArgs e)
        {
            int ind = cbPresets.SelectedIndex;
            _cr.Budgets[cbBudgets.SelectedIndex].Presets.Change(ind, Bezeichnung, Worth);
            cbPresets.SelectedIndex = ind;
            comboBoxPresets_SelectedIndexChanged(comboBox1, new EventArgs());

            // Form3 fm3 = new Form3(_cr.Budgets[cbBudgets.SelectedIndex].Presets.Namen[cbPresets.SelectedIndex],
            //_cr.Budgets[cbBudgets.SelectedIndex].Presets.Werte[cbPresets.SelectedIndex]);
            // if (fm3.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            // {
            //     int ind = cbPresets.SelectedIndex;
            //     _cr.Budgets[cbBudgets.SelectedIndex].Presets.Change(cbPresets.SelectedIndex, fm3.Bezeichnung, fm3.Wert);
            //     cbPresets.SelectedIndex = ind;
            //     comboBoxPresets_SelectedIndexChanged(comboBox1, new EventArgs());
            // }
        }
        private void Presets_NamenChange(List<string> obj)
        {
            if (obj.Count >= 0)
            {
                cbPresets.Enabled = true;
            }
            else cbPresets.Enabled = false;
            bool added = cbPresets.Items.Count < obj.Count;
            cbPresets.Items.Clear();
            cbPresets.Items.AddRange(obj.ToArray());
            if (added) cbPresets.SelectedIndex = obj.Count - 1;
            else cbPresets.SelectedIndex = -1;

        }
        private void comboBoxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPresets.SelectedIndex != -1 && cbBudgets.SelectedIndex != -1)
            {
                textBox1.Text = _cr.Budgets[cbBudgets.SelectedIndex].Presets.Namen[cbPresets.SelectedIndex];
                textBox2.Text = _cr.Budgets[cbBudgets.SelectedIndex].Presets.Werte[cbPresets.SelectedIndex].ToString().TrimStart('-');
                if (textBox2.Text == "0") textBox2.Text = "";
                if (_cr.Budgets[cbBudgets.SelectedIndex].Presets.Werte[cbPresets.SelectedIndex] <= 0) comboBox1.SelectedIndex = 0;
                else comboBox1.SelectedIndex = 1;
            }
        }

        private void presetsTSMI_DDO(object sender, EventArgs e)
        {
            if (cbPresets.SelectedIndex != -1)
            {
                ändernToolP.Visible = true;
                //neuToolP.Visible =
                löschenToolP.Visible = true;
                //löschenToolP.Visible =
                //clearToolP.Visible = false;
            }
            else
            {
                ändernToolP.Visible = false;
                //neuToolP.Visible =
                löschenToolP.Visible = false;
                //clearToolP.Visible = true;

            }
        }
        private void löschenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _cr.Budgets[cbBudgets.SelectedIndex].Presets.RemoveAt(cbPresets.SelectedIndex);
            clearToolStripMenuItem_Click(clearToolP, new EventArgs());
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
            comboBox1.SelectedIndex = 0;
            cbPresets.SelectedIndex = -1;
        }
        #endregion

        #region ListView
        private void Form2_ListViewChange(ListViewItem[] obj)
        {
            listView1.Enabled = true;
            listView1.Items.Clear();
            for (int i = 0; i < obj.Length; i++)
                listView1.Items.Add(obj[i]);

            // statistiken
            GeldManagement gm = _cr.Budgets[cbBudgets.SelectedIndex]
                 .MonateGM[cbMonate.SelectedIndex];

            userControlStatistik1.Actualisieren(
                gm.ProzentVonVerwendet, gm.Einnahmen,
                gm.Ausgaben);

            userControlStatistik2.Actualisieren(
                _cr.Budgets[cbBudgets.SelectedIndex]
                .Ds_ProzentVonVerwendet,
                _cr.Budgets[cbBudgets.SelectedIndex].
                Ds_Einnahmen, _cr.Budgets[cbBudgets
                .SelectedIndex].Ds_Ausgaben);

            gm = _cr.Budgets[cbBudgets.SelectedIndex].GetAktuelleWoche(cbMonate.SelectedIndex);
            if (gm.Transfered.Count == 0) userControlStatistik4.Actualisieren();
            else userControlStatistik4.Actualisieren(gm.ProzentVonVerwendet, gm.Einnahmen, gm.Ausgaben);

        }
        private void ändernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count != 1) return;
            List<Transfer> trans = _cr.Budgets[cbBudgets.SelectedIndex].MonateGM[cbMonate.SelectedIndex].Transfered;

            Transfer d = trans[(int)listView1.SelectedItems[0].Tag];
            textBox1.Text = d.Bezeichnung;
            textBox2.Text = d.Wert.ToString().TrimStart('-');
            if (d.Wert < 0) comboBox1.SelectedIndex = 0; else comboBox1.SelectedIndex = 1;
            dateTimePicker1.Value = d.Datum;
            löschenToolStripMenuItem_Click(löschenToolStripMenuItem, new EventArgs());
        }
        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> ind = new List<int>();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
                ind.Add((int)listView1.SelectedItems[i].Tag);
            ind.Sort();
            for (int i = 0; i < ind.Count; i++)
                _cr.Budgets[cbBudgets.SelectedIndex].RemoveAt(cbMonate.SelectedIndex, ind[ind.Count - 1 - i]);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userControlStatistik3.Actualisieren();
            if (listView1.SelectedItems.Count == 0)
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                if (tabControl1.SelectedIndex == 2) tabControl1.SelectTab(0);
            }
            else if (listView1.SelectedItems.Count == 1)
            {
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true;
                if (tabControl1.SelectedIndex == 2) tabControl1.SelectTab(0);
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = true;
                List<int> l = new List<int>();
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    l.Add((int)listView1.SelectedItems[i].Tag);
                GeldManagement gm = _cr.GetAuswahl(cbBudgets.SelectedIndex, cbMonate.SelectedIndex, l);
                userControlStatistik3.Actualisieren(gm.ProzentVonVerwendet, gm.Einnahmen, gm.Ausgaben);
                tabControl1.SelectTab(2);
            }
        }
        #endregion

    }
}