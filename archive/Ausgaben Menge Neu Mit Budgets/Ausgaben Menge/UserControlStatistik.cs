using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserControlStatistik : UserControl
    {
        double _prz = 0;
        public string Bezeichnung { get { return label1.Text; } set { label1.Text = value; } }
        public UserControlStatistik()
        {
            InitializeComponent();
            Actualisieren();
        }
        public void Actualisieren(double prozent, double einnahmen, double ausgaben)
        {
            panel1.BackColor = panel4.BackColor = Color.LightGreen;
            panel2.BackColor = panel3.BackColor = Color.LightCoral;
            string tex = "Einnahmen: " + Math.Round(einnahmen, 2).ToString() + " " + Do.GE + "\n";
            // tex += " = " + Math.Round(einnahmen + budget, 2).ToString() + " GE";
            tex += "Ausgaben: " + Math.Round(ausgaben, 2).ToString() + " " + Do.GE;
            tex += "\n\n" + Math.Round(prozent, 2).ToString() + "% verwendet";
            toolTip1.SetToolTip(panel1, tex);
            toolTip1.SetToolTip(panel2, tex);
            label2.Text = Math.Round(ausgaben, 2).ToString() + " " + Do.GE;
            label3.Text = Math.Round(einnahmen, 2).ToString() + " " + Do.GE;
            _prz = prozent;
            labelTest1.Text = ""; // weil sonst die alte zahl übermalt wird, kp warum
            labelTest1.Text = Math.Round(_prz, 0).ToString() + "%";
            ActAnzeige();
        }
        public void Actualisieren()
        {
            panel2.Width = 0;
            panel1.BackColor = Color.Lavender;
            label2.Text = "";
            label3.Text = "";
            labelTest1.Text = "0%";
        }
        void ActAnzeige()
        {
            double tmpPro = _prz;
            if (tmpPro > 100) tmpPro = 100;
            else if (tmpPro < 0) tmpPro = 0;
            panel2.Width = Convert.ToInt32(Math.Round((double)panel1.Width / 100 * tmpPro, 0));
        }


        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            ActAnzeige();
        }
    }
}
