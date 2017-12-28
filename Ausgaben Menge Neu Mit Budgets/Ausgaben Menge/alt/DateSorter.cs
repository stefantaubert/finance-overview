using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

class DateSorter
{
    List<string> _monate = new List<string>();
    List<List<Ausgabe>> _ausgaben = new List<List<Ausgabe>>();
    string _euros;
    public string Euros { get { return _euros; } }

    public string[] Monate { get { return _monate.ToArray(); } }

    public void Sort(Ausgabe[] ausgaben)
    {
        _monate.Clear();
        _ausgaben.Clear();
        _monate.Add("Alle");
        List<DateTime> _zeiten = new List<DateTime>();
        foreach (var item in ausgaben)
            _zeiten.Add(item.Datum);
        // _zeiten.Sort();
        for (int i = 0; i < _zeiten.Count; i++)
        {
            string monthName = Application.CurrentCulture.DateTimeFormat.MonthNames[_zeiten[i].Month - 1];
            string monat = monthName + " " + _zeiten[i].Year.ToString();
            if (!_monate.Contains(monat))
                _monate.Add(monat);
            int index = _monate.IndexOf(monat);
            do _ausgaben.Add(new List<Ausgabe>());
            while (_ausgaben.Count < _monate.Count);
            _ausgaben[index].Add(ausgaben[i]);
        }
    }

    public Ausgabe[] GetAusgaben(int index)
    {
        if (index == -1) return new Ausgabe[] { };
        List<Ausgabe> ausg = new List<Ausgabe>();
        double euro = 0;
        if (index == 0)
            foreach (var item in _ausgaben)
                foreach (var item2 in item)
                {
                    if (item2.Plus.Contains("+")) euro += Convert.ToDouble(item2.Kosten);
                    else euro -= Convert.ToDouble(item2.Kosten);
                    ausg.Add(item2);
                }
        else
            foreach (var item2 in _ausgaben[index])
            {
                if (item2.Plus.Contains("+")) euro += Convert.ToDouble(item2.Kosten);
                else euro -= Convert.ToDouble(item2.Kosten);
                ausg.Add(item2);
            }
        _euros = Do.ZweiKommastellen(euro.ToString()) + " EUR";
        if (!_euros.StartsWith("-")) _euros = "+" + _euros;
        return ausg.ToArray();
    }

}