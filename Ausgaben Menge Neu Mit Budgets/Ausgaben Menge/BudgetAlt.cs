using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

public class BudgetKopie
{
    public event Action<ListViewItem[]> ListViewChange;
    public event Action<string[]> MonateChange;

    string _name;
    public string Name { get { return _name; } set { _name = value; } }

    // List<string> _monate = new List<string>();
    public List<string> Monate
    {
        get
        {
            List<string> ausg = new List<string>();
            for (int i = 0; i < _gm.Count; i++)
            {
                ausg.Add(_gm[i].Name);
            }
            return ausg;
        }
    } // nur wegen xml
    public List<string> Monatsbezeichnungen
    {
        get
        {
            List<string> ausg = new List<string>();
            foreach (var item in _gm)
                ausg.Add(item.Name);
            //ausg.Add(Application.CurrentCulture.DateTimeFormat.MonthNames
            //    [Convert.ToInt32(item.Substring(4, 2).TrimStart('0')) - 1] + " " + item.Substring(0, 4));
            return ausg;
        }
    }

    List<GeldManagement> _gm = new List<GeldManagement>();
    public List<GeldManagement> GeldManagement { get { return _gm; } }

    Preset _presets = new Preset();
    public Preset Presets { get { return _presets; } set { _presets = value; } }

    public GeldManagement GetAktuelleWoche(int indMonat)
    {
        GeldManagement ausg = new GeldManagement();
        if ((indMonat >= 0) && indMonat < _gm.Count && _gm.Count == _monate.Count)
            for (int i = 0; i < _gm[indMonat].Transfered.Count; i++)
            {
                Transfer tra = _gm[indMonat].Transfered[_gm[indMonat].Transfered.Count - 1 - i];
                ausg.DateZeit = tra.Datum;
                if (IsThisWeek(tra.Datum))
                    ausg.Add(tra);
            }
        return ausg;
    }
    public ListViewItem[] GetItems(int indMonat)
    {
        List<ListViewItem> ausg = new List<ListViewItem>();
        if ((indMonat >= 0) && indMonat < _gm.Count && _gm.Count == _monate.Count)
        {
            for (int i = 0; i < _gm[indMonat].Transfered.Count; i++)
            {
                int indäx = _gm[indMonat].Transfered.Count - 1 - i;
                ListViewItem lvi = new ListViewItem(new string[] 
                {   
             _gm[indMonat].Transfered[indäx].Datum.ToString("dd.MM.yy [ddd]"),
             _gm[indMonat].Transfered[indäx].Bezeichnung,
             Do.ZweiKommastellen(_gm[indMonat].Transfered[indäx].Wert.ToString()) + " " +Do.GE
                });
                if (IsThisWeek(_gm[indMonat].Transfered[_gm[indMonat].Transfered.Count - 1 - i].Datum))
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
    private bool IsThisWeek(DateTime day)
    {
        bool ausg = false;
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
    public void Add(Transfer tr)
    {
        string id = Do.GetID(tr.Datum);
        int ind = _monate.BinarySearch(id);

        if (ind < 0)
        {
            //   _monate.Add(id);
            _monate.Insert(~ind, id);
            GeldManagement gm = new global::GeldManagement();
            gm.DateZeit = tr.Datum;
            gm.Add(tr);
            _gm.Insert(~ind, gm);
            if (MonateChange != null) MonateChange(Monatsbezeichnungen.ToArray());
            // kommt dann wenn monat changed if (ListViewChange != null) ListViewChange(GetItems(_monate.BinarySearch(id)));
        }
        else
        {
            _gm[ind].Add(tr);
            if (MonateChange != null) MonateChange(Monatsbezeichnungen.ToArray());
            //  if (ListViewChange != null)
            //     ListViewChange(GetItems(ind));
        }
    }
    public double EinnahmenDS
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
    public double AusgabenDS
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
    public double KontostandDS
    {
        get { return AusgabenDS + EinnahmenDS; }
    }
    public double ProzentVonVerwendetDS
    {
        get
        {
            if (EinnahmenDS == 0) return 100;
            return 100 / EinnahmenDS * (AusgabenDS * -1);
            // return 100 / (_budget + EinnahmenDS) * (AusgabenDS * -1);
        }
    }
    public void RemoveAt(int indMonat, int indTran)
    {
        if ((indMonat >= 0) && indMonat < _gm.Count && _gm.Count == _monate.Count)
        {
            if (indTran >= 0 && indTran < _gm[indMonat].Transfered.Count)
            {
                _gm[indMonat].RemoveAt(indTran);
                if (_gm[indMonat].Transfered.Count == 0)
                {
                    _gm.RemoveAt(indMonat);
                    _monate.RemoveAt(indMonat);
                    if (MonateChange != null) MonateChange(Monatsbezeichnungen.ToArray());
                    // da muss man dann den combo index ändern aufs letzte
                }
                else
                    if (ListViewChange != null) ListViewChange(GetItems(indMonat));
            }
        }
    }
    public void RemoveMonat(int indMonat)
    {
        if ((indMonat >= 0) && indMonat < _gm.Count && _gm.Count == _monate.Count)
        {
            _gm.RemoveAt(indMonat);
            _monate.RemoveAt(indMonat);
            if (MonateChange != null) MonateChange(Monatsbezeichnungen.ToArray());
        }
    }
}