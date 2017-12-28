namespace AusgabenManager
{
    public class Transfer
    {
        public string Bezeichnung { get; set; }
        public double Wert { get; set; }
        public System.DateTime Datum { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute]
        public int TmpInd { get; set; }
    }
}