using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace AusgabenManager
{
    public class Verwaltung
    {
        public const string Währung = "EUR";
        private string _path = Application.StartupPath + "\\saves.xml";

        [System.Xml.Serialization.XmlIgnoreAttribute]
        public string Filter { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute]
        public List<Transfer> GefilterteEinträge
        {
            get
            {
                List<Transfer> ausg = new List<Transfer>();
                for (int i = 0; i < Einträge.Count; i++)
                    if (Filter.Trim() == "" || (Einträge[i].Bezeichnung + Einträge[i].Datum.ToShortDateString() + Einträge[i].Wert.ToString()).ToLower().Contains(Filter.Trim().ToLower()))
                        ausg.Add(Einträge[i]);
                return ausg;
            }
        }
        public List<Transfer> Einträge { get; set; }
        public List<string> Presets { get; set; }

        public Verwaltung()
        {
            Presets = new List<string>();
            Einträge = new List<Transfer>();
            Filter = "";
        }

        public static bool IsThisWeek(DateTime day)
        {
            DateTime now = DateTime.Now;//.AddDays(-22);
            DayOfWeek aktMon = now.DayOfWeek;
            while (aktMon != DayOfWeek.Monday)
            {
                now = now.AddDays(-1);
                aktMon = now.DayOfWeek;
            }
            long ticksBegin = new DateTime(now.Year, now.Month, now.Day).Ticks;
            long ticksSeven = new DateTime(1, 1, 7).Ticks;
            long ticksEnd = new DateTime(day.Year, day.Month, day.Day).Ticks;
            return ticksEnd >= ticksBegin && ticksEnd <= (ticksBegin + ticksSeven);
        }

        private List<long> Datetimes
        {
            get
            {
                List<long> ausg = new List<long>();
                for (int i = 0; i < Einträge.Count; i++)
                    ausg.Add(Einträge[i].Datum.Ticks);
                return ausg;
            }
        }

        public bool EintragHinzufügen(string t, DateTime dt)
        {
            try
            {
                int ind = t.IndexOf(" ");
                double betrag = Convert.ToDouble(t.Substring(0, ind));
                string bez = t.Substring(ind + 1, t.Length - ind - 1);
                EintragHinzufügen(new Transfer() { Bezeichnung = bez.Trim(), Wert = betrag, Datum = dt });
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void SetzeIndexes()
        {
            for (int i = 0; i < Einträge.Count; i++)
                Einträge[i].TmpInd = i;
        }


        private void EintragHinzufügen(Transfer t)
        {
            int ind = Datetimes.BinarySearch(t.Datum.Ticks, new DescendingComparer());
            Einträge.Insert(ind < 0 ? ~ind : ind, t);
            SetzeIndexes();
        }
        public void EintragLöschen(int ind)
        {
            Einträge.RemoveAt(ind);
            SetzeIndexes();
        }

        public Finanzüberblick Finanzblick(List<Transfer> trans)
        {
            return new Finanzüberblick(trans);
        }
        public Finanzüberblick Finanzblick()
        {
            return new Finanzüberblick(Einträge);
        }
        public Finanzüberblick Finanzblick(List<int> indexes)
        {
            List<Transfer> tmp = new List<Transfer>();
            foreach (var item in indexes)
            {
                tmp.Add(Einträge[item]);
            }
            return new Finanzüberblick(tmp);
        }

        public void Speichern()
        {
            Serialisieren<Verwaltung>(this, _path);
        }


        public void Laden()
        {
            Verwaltung v = Deserialisieren<Verwaltung>(_path);
            if (v == null) return;
            this.Einträge = v.Einträge;
            this.Presets = v.Presets;
            SetzeIndexes();
        }

        private static void Serialisieren<T>(T obj, string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
                new XmlSerializer(typeof(T)).Serialize(fs, obj);
        }

        private static T Deserialisieren<T>(string file)
        {
            //  return File.Exists(file) ? ((T)(new XmlSerializer(typeof(T))).Deserialize(new FileStream(file, FileMode.Open))) : default(T);
            if (!File.Exists(file)) return default(T);
            else using (FileStream fs = new FileStream(file, FileMode.Open))
                    return (T)(new XmlSerializer(typeof(T))).Deserialize(fs);
        }
    }
}