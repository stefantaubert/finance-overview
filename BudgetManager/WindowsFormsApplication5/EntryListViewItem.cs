using System.Drawing;
using System.Windows.Forms;

namespace BudgetManager
{
    public class EntryListViewItem : ListViewItem
    {
        public EntryListViewItem(Entry entry) : base(new string[]
                {
                    entry.DateTime.ToString("dd.MM.yy (ddd)"),
                    entry.Label,
                    string.Format("{0} {1}",  entry.Value.ToString("0.00"), " EUR")
                })
        {
            this.ForeColor = entry.IsThisWeek() ? Color.Blue : Color.Black;
            this.CurrentEntry = entry;
        }

        public Entry CurrentEntry
        {
            get;
            private set;
        }
    }
}
