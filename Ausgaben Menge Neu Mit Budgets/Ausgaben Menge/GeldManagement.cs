using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

public class GeldManagement
{
    DateTime _dt;
    public DateTime DateZeit { get { return _dt; } set { _dt = value; } }

    public string Monatsbezeichnung { get { return Do.GetID(_dt); } }

    public string Name
    {
        get
        {
            return Application.CurrentCulture.DateTimeFormat.MonthNames
                [Convert.ToInt32(Monatsbezeichnung.Substring(4, 2).TrimStart('0')) - 1] + " " + Monatsbezeichnung.Substring(0, 4);
        }
    }

    List<Transfer> _trans = new List<Transfer>();
    public List<Transfer> Transfered { get { return _trans; } set { _trans = value; } }

    public double Einnahmen
    {
        get
        {
            double wert = 0;
            foreach (var item in _trans)
            {
                if (item.Wert > 0) wert += item.Wert;
            }
            return wert;
        }
    }
    public double Ausgaben
    {
        get
        {
            double wert = 0;
            foreach (var item in _trans)
            {
                if (item.Wert < 0) wert += item.Wert;
            }
            return wert;
        }
    }
    public double Kontostand
    {
        get { return Ausgaben + Einnahmen; }
    }
    public double ProzentVonVerwendet
    {
        get
        {
            //if (Einnahmen == 0 && Ausgaben == 0) return 0;
            //else
            if (Einnahmen == 0) return 100;
            else return 100 / Einnahmen * (Ausgaben * -1);
        }
    }

    public void Sort()
    {
        List<string> ausg = new List<string>();
        for (int i = 0; i < _trans.Count; i++)
        {
            string day = _trans[i].Datum.Day.ToString();
            ausg.Add(new String('0', 2 - day.Length) + day);
        }
       // ausg.Sort();
        Sortiere.SetArray(ausg);
        Sortiere.Sort<Transfer>(ref _trans);
    }
    public void Clear()
    {
        _trans.Clear();
    }
    public void Add(Transfer tr)
    {
        if (Do.GetID(tr.Datum) == Do.GetID(_dt))
        {
            _trans.Add(tr);
            //List<string> a = Datums;
            //int ind = Datums.BinarySearch(tr.Datum.Day.ToString());
            //if (ind < 0) ind = ~ind;
            //_trans.Insert(ind, tr);
            // _datums.Insert(ind, tr.Datum.Day.ToString());
        }
        else throw new Exception("Falscher Monat");
    }
    public void RemoveAt(int index)
    {
        if (index < _trans.Count && index >= 0)
        {
            _trans.RemoveAt(index);
            //_datums.RemoveAt(index);
        }
        else throw new Exception("Falscher Index");
    }
}