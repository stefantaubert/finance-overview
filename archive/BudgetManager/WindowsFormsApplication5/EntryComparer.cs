using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager
{
    public class EntryComparer : IComparer<Entry>
    {
        public int Compare(Entry x, Entry y)
        {
            return x.DateTime.CompareTo(y.DateTime);
        }
    }
}
