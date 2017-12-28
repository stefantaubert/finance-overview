using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Model : ISerializable
    {
        private int currentId;
        private const string CurrencyUnit = "€";

        public Entries Entries
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void CreateEntry(DateTime moment, double quantity, string description)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveEntry(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
