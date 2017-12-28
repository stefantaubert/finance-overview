using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.Globalization.CultureInfo.
                CurrentCulture.NumberFormat.NumberDecimalSeparator != ",") { MessageBox.Show("Kein Komma!"); return; }
            else
                Application.Run(new Form4());
        }
    }
}
