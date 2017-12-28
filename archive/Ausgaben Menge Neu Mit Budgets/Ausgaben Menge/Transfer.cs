using System;
using System.Text;

public class Transfer
{
    string _bez;
    double _wert;
    DateTime _datum;
    public string Bezeichnung { get { return _bez; } set { _bez = value; } }
    public double Wert { get { return _wert; } set { _wert = value; } }
    public DateTime Datum { get { return _datum; } set { _datum = value; } }
}
