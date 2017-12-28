using System;
using System.Runtime.Serialization;

namespace BudgetManager
{
    [Serializable]
    public struct Entry : ISerializable
    {
        public Entry(SerializationInfo info, StreamingContext context)
        {
            this.Label = info.GetString("Label");
            this.Value = info.GetDecimal("Value");
            this.DateTime = info.GetDateTime("DateTime");
        }

        public string Label
        {
            get;
            set;
        }

        public decimal Value
        {
            get;
            set;
        }

        public DateTime DateTime
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Value, this.Label);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Label", this.Label);
            info.AddValue("Value", this.Value);
            info.AddValue("DateTime", this.DateTime);
        }

        /// <summary>
        /// Prüft ob die angegebene Zeichenkette einen Wert enthält.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static bool TryParse(string entry, out Entry newEntry)
        {
            var value = entry.Trim();
            var index = value.IndexOf(" ");
            bool ok = index != -1;

            newEntry = default(Entry);

            if (ok)
            {
                var tmpResult = default(decimal);

                ok = Decimal.TryParse(value.Substring(0, index), out tmpResult);

                newEntry = new Entry();
                newEntry.Value = tmpResult;
                newEntry.Label = value.Substring(index + 1);
            }

            return ok;
        }

        public bool IsThisWeek()
        {
            var now = DateTime.Now;
            var currentDay = now.DayOfWeek;

            while (currentDay != DayOfWeek.Monday)
            {
                now = now.AddDays(-1);
                currentDay = now.DayOfWeek;
            }

            var ticksBegin = new DateTime(now.Year, now.Month, now.Day).Ticks;
            var ticksSeven = new DateTime(1, 1, 7).Ticks;
            var ticksEnd = new DateTime(this.DateTime.Year, this.DateTime.Month, this.DateTime.Day).Ticks;

            return ticksEnd >= ticksBegin && ticksEnd <= (ticksBegin + ticksSeven);
        }
    }
}
