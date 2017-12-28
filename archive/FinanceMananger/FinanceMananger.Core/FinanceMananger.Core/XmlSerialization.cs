using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace FinanceMananger.Core
{
    public static class XmlSerialization
    {
        public static void SerializeModel(Model obj, string fileName)
        {
            var serializer = new XmlSerializer(typeof(Model));

            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, obj);
            }
        }

        public static Model DeserializeModel(string fileName)
        {
            var serializer = new XmlSerializer(typeof(Model));

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return (Model)serializer.Deserialize(stream);
            }
        }
    }
}
