using System;
using System.Collections.Generic;
using System.Text;

public class Preset
{
    List<string> _namen = new List<string>();
    public List<string> Namen { get { return _namen; } set { _namen = value; } }
    List<double> _werte = new List<double>();
    public List<double> Werte { get { return _werte; } set { _werte = value; } }
    public event Action<List<string>> NamenChange;
    public void Add(string name, double wert)
    {
        _namen.Add(name);
        _werte.Add(wert);
        if (NamenChange != null) NamenChange(_namen);
    }
    public void RemoveAt(int ind)
    {
        if (ind < 0 || ind >= _werte.Count || _werte.Count != _namen.Count) return;
        _namen.RemoveAt(ind);
        _werte.RemoveAt(ind);
        if (NamenChange != null) NamenChange(_namen);
    }
    public void Change(int ind, string name, double wert)
    {
        if (ind < 0 || ind >= _werte.Count || _werte.Count != _namen.Count) return;
        string oldN = _namen[ind];
        _namen[ind] = name;
        _werte[ind] = wert;
        if (NamenChange != null && oldN != name) NamenChange(_namen);
    }
}
