using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BudgetManager
{
    [Serializable]
    public class Model : ISerializable
    {
        public Model()
        {
            this.Entries = new List<Entry>();
            this.Templates = new List<string>();
        }

        public Model(SerializationInfo info, StreamingContext context)
        {
            this.Entries = (List<Entry>)info.GetValue("Entries", typeof(List<Entry>));
            this.Templates = (List<string>)info.GetValue("Templates", typeof(List<string>));
        }

        public List<Entry> Entries { get; private set; }

        public List<string> Templates { get; private set; }

        internal void AddEntry(Entry entry)
        {
            this.Entries.Add(entry);

            this.Entries.Sort(new EntryComparer());
        }

        public void DeleteEntry(Entry entry)
        {
            this.Entries.Remove(entry);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Entries", this.Entries);
            info.AddValue("Templates", this.Templates);
        }
    }
}
