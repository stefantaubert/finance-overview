using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
public class Test : PropertyBase
{
    [XmlIgnore()]
    public Color Farbe
    {
        set
        {
            Serializer.Set<Color>(value);
        }
        get
        {
            return Serializer.Get<Color>();
        }
    }
    [XmlIgnore()]
    public Color Farbe1
    {
        get
        {
            return (Color)new ColorConverter().ConvertFromString(Serializer.GetProperty("Farbe1"));
        }
        set
        {
            Serializer.SetProperty("Farbe", new ColorConverter().ConvertToString(value));
        }
    }
    [XmlIgnore()]
    public Font Schriftart
    {
        set
        {
            Serializer.Set<Font>(value);
        }
        get
        {
            return Serializer.Get<Font>();
        }
    }
    [XmlIgnore()]
    public Rectangle Viereck
    {
        get { return Serializer.Get<Rectangle>(); }
        set { Serializer.Set<Rectangle>(value); }

    }
    [XmlIgnore()]
    public string Zeichenkette
    {
        get { return Serializer.Get<string>(); }
        set { Serializer.Set<string>(value); }
    }
    [XmlIgnore()]
    public int Zahl
    {
        get { return Serializer.Get<int>(); }
        set { Serializer.Set<int>(value); }
    }
    [XmlIgnore()]
    public DateTime Datum
    {
        get { return Serializer.Get<DateTime>(); }
        set { Serializer.Set<DateTime>(value); }
    }
    public Test()
    { }
}

[Serializable]
public abstract class PropertyBase
{
    public PropertySerializer Serializer { get; set; }
    public PropertyBase()
    {
        Serializer = new PropertySerializer();
    }
}

[Serializable]
public class Property
{
    [XmlAttribute()]
    public string Name;
    [XmlAttribute()]
    public string Value;
    public Property()
    { }
    public Property(string name, string value)
    {
        Name = name;
        Value = value;
    }
    public override string ToString()
    {
        return Name + " : " + Value;
    }
}
[Serializable]
public class PropertySerializer
{
    /// <summary>
    /// Die Liste mit den Eigenschaften und deren Werten.
    /// </summary>
    public List<Property> Properties { get; set; }
    /// <summary>
    /// Initialisiert eine neue Instanz dieser Klasse.
    /// </summary>
    public PropertySerializer()
    {
        Properties = new List<Property>();
    }

    /// <summary>
    /// Trägt die Eigenschaft und deren Wert in die Liste <see cref="Properties"/> ein.
    /// Nicht vorhandene Eigenschaften werden hinzugefügt, vorhandene aktualisiert.
    /// </summary>
    /// <param name="name">Der Name der Eigenschaft.</param>
    /// <param name="value">Der Wert der Eigenschaft</param>
    public void SetProperty(string name, string value)
    {
        int i = Properties.FindIndex(x => x.Name == name);

        if (i > -1)
        {
            Properties[i].Value = value;
        }
        else
        {
            Properties.Add(new Property(name, value));
        }
    }
    /// <summary>
    /// Ruft den Wert der angegebenen Eigenschaft ab.
    /// </summary>
    /// <param name="name">Der Name der Eigenschaft.</param>
    /// <returns>Den Wert der Eigenschaft, oder eine leere Zeichenkette, wenn die
    /// Eigenschaft nicht vorhanden ist.</returns>
    public string GetProperty(string name)
    {
        int i = Properties.FindIndex(x => x.Name == name);
        if (i > -1)
        {
            return Properties[i].Value;
        }
        else
        {
            return String.Empty;
        }
    }
    /// <summary>
    /// Legt den Wert einer Eigenschaft fest.
    /// </summary>
    /// <typeparam name="T">Der Typ der Eigenschaft.</typeparam>
    /// <param name="value">Der Wert der Eigenschaft.</param>
    public void Set<T>(T value)
    {
        string s = new StackTrace(System.Threading.Thread.CurrentThread, true)
        .GetFrame(1)
        .GetMethod().Name;

        s = s.Substring(4, s.Length - 4);

        SetProperty(s, TypeDescriptor.GetConverter(typeof(T)).ConvertToString(value));
    }
    /// <summary>
    /// Ruft den Wert einer Eigenschaft ab.
    /// </summary>
    /// <typeparam name="T">Der Typ der Eigenschaft.</typeparam>
    /// <returns>Den Wert der Eigenschaft.</returns>
    public T Get<T>()
    {
        string s = new StackTrace(System.Threading.Thread.CurrentThread, true)
        .GetFrame(1)
        .GetMethod().Name;

        s = s.Substring(4, s.Length - 4);

        string value = GetProperty(s);

        return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
    }

    /// <summary>
    /// Speichert eine Klasse.
    /// </summary>
    /// <typeparam name="T">Der Typ der zu ladenden Klasse.</typeparam>
    /// <param name="candidate">Die zu speichernde Klasse.</param>
    /// <param name="path">Der vollqualifizierte Name der Zieldatei.</param>
    public static void Save<T>(T candidate, string path) where T : PropertyBase
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        using (FileStream str = new FileStream(path, FileMode.Create))
        {
            ser.Serialize(str, candidate);
        }
    }
    /// <summary>
    /// Läd eine Klasse.
    /// </summary>
    /// <typeparam name="T">Der Typ der zu ladenden Klasse.</typeparam>
    /// <param name="path">Der vollqualifizierte Name der Quelldatei.</param>
    /// <returns>Die geladene Instanz der Klasse.</returns>
    public static T Load<T>(string path) where T : PropertyBase
    {
        XmlSerializer xser = new XmlSerializer(typeof(T));
        T ps;

        using (StreamReader sr = new StreamReader(path))
        {
            ps = (T)xser.Deserialize(sr);
            sr.Close();
        }

        return ps;
    }
}