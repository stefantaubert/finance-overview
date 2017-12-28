using System;
using System.Collections.Generic;
using System.Text;

static class Do
{
    public static string GE = "€";
    public static string All = "Alles";
    static public string GetID(DateTime dt)
    {
        return dt.Year.ToString() + new String('0', 2 - dt.Month.ToString().Length) + dt.Month.ToString();
    }
    static public bool IsThisWeek(DateTime day)
    {
        DateTime now = DateTime.Now;//.AddDays(-22);
        DayOfWeek aktMon = now.DayOfWeek;
        while (aktMon != DayOfWeek.Monday)
        {
            now = now.AddDays(-1);
            aktMon = now.DayOfWeek;
        }
        long ticksBegin = new DateTime(now.Year, now.Month, now.Day).Ticks;
        long ticksSeven = new DateTime(1, 1, 7).Ticks;
        long ticksEnd = new DateTime(day.Year, day.Month, day.Day).Ticks;
        return ticksEnd >= ticksBegin && ticksEnd <= (ticksBegin + ticksSeven);
    }
    static public string ZweiKommastellen(string text)
    {
        string tex = Math.Round(Convert.ToDouble(text), 2).ToString();
        if (tex == "n. def.") return "0,00";
        if (tex.Contains(","))
        {
            int lenght = 1 + tex.IndexOf(",");
            return tex + new String('0', lenght + 2 - tex.Length);
        }
        else return tex + ",00";
    }
    static public string MakePattern(string patt, string text)
    {
        for (int i = 0; i < text.Length; i++)
            if (!patt.Contains(text[i].ToString()))
            { text = text.Remove(i, 1); i--; }
        return text;
    }
    static public string GetWochentag(DateTime dT)
    {
        return string.Format("{0:dddd}", dT);
    }
    static public string MakeOneKomma(string text, bool mitMinus)
    {
        if (text.Trim().TrimStart('+') == "") return "";
        string ausg = String.Empty;
        string patt = "1234567890,";
        string voran = "";
        if (mitMinus && text.StartsWith("-")) voran = "-";
        bool einKomma = false;
        foreach (var item in text)
            if (patt.Contains(Convert.ToString(item)))
                if ((Convert.ToString(item) == ","))
                    if (!einKomma)
                    {
                        ausg += item;
                        einKomma = true;
                    }
                    else continue;
                else
                    ausg += item;
        return voran + ausg;
    }
}