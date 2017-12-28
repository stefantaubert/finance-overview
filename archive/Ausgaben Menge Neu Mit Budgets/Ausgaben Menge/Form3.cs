using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public string Bezeichnung { get { return textBox1.Text.Trim(); } }
        public double Wert
        {
            get
            {
                string zahl = Do.MakeOneKomma(textBox2.Text, true);
                if (zahl == "") return 0; else return Convert.ToInt32(Do.MakeOneKomma(textBox2.Text, true));
            }
        }

        public Form3(bool mitWert)
        {
            InitializeComponent();
            Text = "Element hinzufügen";
            if (!mitWert)
                label2.Visible = textBox2.Visible = comboBox1.Visible = false;
        }
        public Form3(string bez)
        {
            InitializeComponent();
            Text = "Element ändern";
            textBox1.Text = bez.Trim();
            label2.Visible = textBox2.Visible = comboBox1.Visible = false;
        }

        public Form3(string bez, double wert)
        {
            InitializeComponent();
            textBox1.Text = bez.Trim();
            textBox2.Text = wert.ToString();
            comboBox1.SelectedIndex = 0;
            Text = "Element hinzufügen";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox1.Text.Trim() != Do.All)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                MessageBox.Show("Bitte geben Sie eine andere " + label1.Text + " ein!");
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Abort;
        }
    }
}
