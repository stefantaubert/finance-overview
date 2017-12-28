using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

public class Cores
{
    //   int _iBud = -1, _iPre = -1, _iMon = -1;
    string _path = Application.StartupPath + "\\saves.xml";
    public event Action<string[]> BudgetsChange;
    List<Budget> _budgets = new List<Budget>();
    public List<Budget> Budgets { get { return _budgets; } set { _budgets = value; } }
    // public event Action<Transfer> TransferAdded;
    int _aktBudget = 0;
    public int SelectedBudgetIndex { get { return _aktBudget; } set { _aktBudget = value; } }
    bool ContainsAlles { get { return (_budgets.Count > 0 && _budgets[_budgets.Count - 1].Name == Do.All); } }

    public string[] BudgetsNames
    {
        get
        {
            List<string> ausg = new List<string>(); for (int i = 0; i < _budgets.Count; i++)
                ausg.Add(_budgets[i].Name);
            return ausg.ToArray();
        }
    }

    public void Save()
    {
        if (ContainsAlles)
            _budgets.RemoveAt(_budgets.Count - 1);
        XmlSerialisierung<Cores>.Serialisieren(this, _path);
        AddAllesBudget();
    }
    public bool Load()
    {
        bool ret = false;
        if (System.IO.File.Exists(_path))
        {
            Cores c = XmlSerialisierung<Cores>.Deserialisieren(_path);
            _budgets = c.Budgets;
            AddAllesBudget();
            _aktBudget = c.SelectedBudgetIndex;
            ret = true;
        }
        if (BudgetsChange != null) BudgetsChange(BudgetsNames);
        return ret;
    }
    public void AddAllesBudget()
    {
        if (_budgets.Count > 0 && _budgets.Count < 3)
        {
            if (_budgets[_budgets.Count - 1].Name == Do.All)
            {
                _budgets.RemoveAt(_budgets.Count - 1);
                return;
            }
        }
        if (_budgets.Count <= 1) return;
        Budget b = new Budget();
        b.Name = Do.All;
        foreach (var item in _budgets)
            if (item.Name != Do.All)
                foreach (var item2 in item.MonateGM)
                    foreach (var item3 in item2.Transfered)
                        b.Add(item3);
        if (ContainsAlles)
        {
            Budget bud = _budgets[_budgets.Count - 1];
            bud.MonateGM.Clear();
            for (int i = 0; i < b.MonateGM.Count; i++)
            {
                for (int j = 0; j < b.MonateGM[i].Transfered.Count; j++)
                {
                    bud.Add(b.MonateGM[i].Transfered[j]);
                }
            }
        }
        else _budgets.Add(b);
    }
    public void AddBudget(Budget bdg)
    {
        if (ContainsAlles) _budgets.RemoveAt(_budgets.Count - 1);
        _budgets.Add(bdg);
        AddAllesBudget();
        if (BudgetsChange != null) BudgetsChange(BudgetsNames);
    }
    public void RemoveBudgetAt(int ind)
    {
        if (ind >= 0 && ind < _budgets.Count)
        {
            _budgets.RemoveAt(ind);
            AddAllesBudget();
            if (BudgetsChange != null) BudgetsChange(BudgetsNames);
        }
    }
    public void Change(int ind, string bez)
    {
        if (ind >= 0 && ind < _budgets.Count)
        {
            _budgets[ind].Name = bez;
            // _budgets[ind].Wert = bud.Wert;
            // if (_budgets[ind].Name != bud.Name)
            if (BudgetsChange != null) BudgetsChange(BudgetsNames);
        }
    }
    public void ResetBudget(int ind)
    {
        if (ind >= 0 && ind < _budgets.Count)
        {
            _budgets[ind].MonateGM.Clear();
            AddAllesBudget();
            if (BudgetsChange != null) BudgetsChange(BudgetsNames);
        }
    }
    public GeldManagement GetAuswahl(int budInd, int monInd, List<int> ind)
    {
        List<Transfer> tr = new List<Transfer>();
        for (int i = 0; i < ind.Count; i++)
            tr.Add(Budgets[budInd].MonateGM[monInd].Transfered[ind[i]]);
        GeldManagement gm = new GeldManagement();
        if (tr.Count == 0) return gm;
        gm.DateZeit = tr[0].Datum;
        for (int i = 0; i < tr.Count; i++)
            gm.Add(tr[i]);
        //gm.Sort(); brauch ich ne weil nur die statistik gilt
        return gm;
    }
}
