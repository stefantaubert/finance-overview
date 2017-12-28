using System;
using System.Collections.Generic;
using System.Text;

namespace AusgabenManager
{
    public class Finanzüberblick
    {
        public string EinnahmenStr { get { return Einnahmen.ToString("0.00") + " " + Verwaltung.Währung; } }
        public string AusgabenStr { get { return Ausgaben.ToString("0.00") + " " + Verwaltung.Währung; } }
        public string KontostandStr { get { return Kontostand.ToString("0.00") + " " + Verwaltung.Währung; } }
        public string ProzentVonVerwendetStr { get { return ProzentVonVerwendet.ToString("0.00") + "%"; } }

        private double Einnahmen { get; set; }
        private double Ausgaben { get; set; }
        private double Kontostand { get; set; }
        private double ProzentVonVerwendet { get; set; }
        // vlt noch durchschnitt ausgabe und durchschnitt einnahme als betrag

        public Finanzüberblick(List<Transfer> transfers)
        {
            double wert = 0;
            foreach (var item in transfers)
            {
                if (item.Wert > 0) wert += item.Wert;
            }
            Einnahmen = wert;
            wert = 0;
            foreach (var item in transfers)
            {
                if (item.Wert < 0) wert += item.Wert;
            }
            Ausgaben = wert;
            Kontostand = Ausgaben + Einnahmen;
            ProzentVonVerwendet = Einnahmen == 0 ? 100 : 100 / Einnahmen * (Ausgaben * -1);
        }
    }
}