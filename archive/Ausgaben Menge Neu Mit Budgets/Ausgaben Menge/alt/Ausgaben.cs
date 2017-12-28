using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

public class Ausgabe
{
    private string _bezeichnung;
    private string _kosten;
    private DateTime _datum;
    private string _positiv;

    public string Bezeichnung { get { return _bezeichnung; } set { _bezeichnung = value; } }
    public string Kosten { get { return _kosten; } set { _kosten = value; } }
    public DateTime Datum { get { return _datum; } set { _datum = value; } }
    public string Plus { get { return _positiv; } set { _positiv = value; } }

    public void SetValue(string bez, string kos, DateTime dat)
    {
        _bezeichnung = bez;
        _positiv = kos.Substring(0, 1);
        _kosten = Do.ZweiKommastellen(kos.Substring(1, kos.Length - 1));
        _datum = dat;
    }
}