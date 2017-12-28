using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ImplementierterAusgabenMananger
{
    public partial class Finanzoverview : UserControl
    {
        public Color Farbe { get { return panel1.BackColor; } set { panel1.BackColor = value; } }
        public string Wert { get { return label2.Text; } set { label2.Text = value; } }

        public Finanzoverview()
        {
            InitializeComponent();
        }

        private void Finanzoverview_SizeChanged(object sender, EventArgs e)
        {
            Height = panel3.Height;
        }
    }
}
