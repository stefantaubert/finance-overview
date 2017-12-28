using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceMananger.Core
{
    public class Model
    {
        public Model()
        {
            this.Transactions = new List<Transaction>();
            this.Presets = new List<string>();
        }

        public List<Transaction> Transactions
        {
            get;
            private set;
        }

        public List<string> Presets
        {
            get;
            private set;
        }
    }
}
