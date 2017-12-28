using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

public class Budget
{
    public event Action<ListViewItem[]> ListViewChange;
    public event Action<string[]> MonateChange;

    private List<string> Monate
    {
        get
        {
            List<string> ausg = new List<string>();
            for (int i = 0; i < _gm.Count; i++)
                ausg.Add(_gm[i].Monatsbezeichnung);
            return ausg;
        }
    }
    private List<string> Monatsbezeichnungen
    {
        get
        {
            List<string> ausg = new List<string>();
            foreach (var item in _gm)
                ausg.Add(item.Name);
            return ausg;
        }
    }

    string _name;
    public string Name { get { return _name; } set { _name = value; } }

    List<GeldManagement> _gm = new List<GeldManagement>();
    public List<GeldManagement> MonateGM { get { return _gm; } }

    Preset _presets = new Preset();
    public Preset Presets { get { return _presets; } set { _presets = value; } }

    public double Ds_Einnahmen
    {
        get
        {
            double wert = 0;
            foreach (var item in _gm)
                foreach (var item2 in item.Transfered)
                    if (item2.Wert > 0) wert += item2.Wert;
            return wert / (double)_gm.Count;
        }
    }
    public double Ds_Ausgaben
    {
        get
        {
            double wert = 0;
            foreach (var item in _gm)
                foreach (var item2 in item.Transfered)
                    if (item2.Wert < 0) wert += item2.Wert;
            return wert / (double)_gm.Count;
        }
    }
    public double Ds_Kontostand
    {
        get { return Ds_Ausgaben + Ds_Einnahmen; }
    }
    public double Ds_ProzentVonVerwendet
    {
        get
        {
            if (Ds_Einnahmen == 0) return 100;
            return 100 / Ds_Einnahmen * (Ds_Ausgaben * -1);
            // return 100 / (_budget + EinnahmenDS) * (AusgabenDS * -1);
        }
    }

    public GeldManagement GetAktuelleWoche(int indMonat)
    {
        GeldManagement ausg = new GeldManagement();
        if ((indMonat >= 0) && indMonat < _gm.Count)
            for (int i = 0; i < _gm[indMonat].Transfered.Count; i++)
            {
                Transfer tra = _gm[indMonat].Transfered[_gm[indMonat].Transfered.Count - 1 - i];
                ausg.DateZeit = tra.Datum;
                if (Do.IsThisWeek(tra.Datum))
                    ausg.Add(tra);
            }
        //ausg.Sort();
        return ausg;
    }
    public ListViewItem[] GetItems(int indMonat)
    {
        List<ListViewItem> ausg = new List<ListViewItem>();
        if ((indMonat >= 0) && indMonat < _gm.Count)
        {
            _gm[indMonat].Sort();
            for (int i = 0; i < _gm[indMonat].Transfered.Count; i++)
            {
                int indäx = _gm[indMonat].Transfered.Count - 1 - i;
                ListViewItem lvi = new ListViewItem(new string[] 
                {   
                    _gm[indMonat].Transfered[indäx].Datum.ToString("dd.MM.yy [ddd]"),
                    _gm[indMonat].Transfered[indäx].Bezeichnung,
                    Do.ZweiKommastellen(_gm[indMonat].Transfered[indäx].Wert.ToString()) + " " +Do.GE
                });
                if (Do.IsThisWeek(_gm[indMonat].Transfered[_gm[indMonat].Transfered.Count - 1 - i].Datum))
                {
                    lvi.Font = new System.Drawing.Font
                       ("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular,
                       System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lvi.ForeColor = System.Drawing.Color.Blue;
                }
                lvi.Tag = indäx;
                ausg.Add(lvi);
            }
        }
        return ausg.ToArray();
    }
    public void MonateEvent()
    {
        if (MonateChange != null) MonateChange(Monatsbezeichnungen.ToArray());
    }
    public void Add(Transfer tr)
    {
        string id = Do.GetID(tr.Datum);
        int ind = Monate.BinarySearch(id);

        if (ind < 0)
        {
            //   _monate.Add(id);
            //   _monate.Insert(~ind, id);
            GeldManagement gm = new global::GeldManagement();
            gm.DateZeit = tr.Datum;
            gm.Add(tr);
            _gm.Insert(~ind, gm);
            MonateEvent();
            // kommt dann wenn monat changed if (ListViewChange != null) ListViewChange(GetItems(_monate.BinarySearch(id)));
        }
        else
        {
            _gm[ind].Add(tr);
            MonateEvent();
            //  if (ListViewChange != null)
            //     ListViewChange(GetItems(ind));
        }
    }
    public void RemoveAt(int indMonat, int indTran)
    {
        if ((indMonat >= 0) && indMonat < _gm.Count && _gm.Count == Monate.Count)
        {
            if (indTran >= 0 && indTran < _gm[indMonat].Transfered.Count)
            {
                _gm[indMonat].RemoveAt(indTran);
                if (_gm[indMonat].Transfered.Count == 0)
                {
                    _gm.RemoveAt(indMonat);
                    MonateEvent();
                    // da muss man dann den combo index ändern aufs letzte
                }
                else
                    if (ListViewChange != null) ListViewChange(GetItems(indMonat));
            }
        }
    }
    public void RemoveMonat(int indMonat)
    {
        if ((indMonat >= 0) && indMonat < _gm.Count)
        {
            _gm.RemoveAt(indMonat);
            MonateEvent();
        }
    }
}