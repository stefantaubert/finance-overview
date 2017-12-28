using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceMananger.Core
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        ////public override int GetHashCode()
        ////{
        ////    return string.Format("{0}{1}{2}", this.Name, this.Date.Ticks.ToString(), this.Amount.ToString());
        ////}
    }
}
