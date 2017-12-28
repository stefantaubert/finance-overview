using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class VolumeBase : ISerializable
    {
        public double Value
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime Moment
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Description
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool IsIncome
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Id
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
