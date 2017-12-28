using System;
using System.Collections.Generic;
using System.Text;

public static class Sortiere
{
    private static List<int> _tmpIndizes = new List<int>();

    public static void SetArray(List<string> a)//, bool gleichSortieren)
    {
        _tmpIndizes.Clear();
        List<int> ausg = new List<int>();
        List<string> tmpA = new List<string>(a);
        for (int i = 0; i < a.Count; i++) tmpA[i] += "_" + i.ToString(); tmpA.Sort();
        for (int i = 0; i < a.Count; i++) ausg.Add(Convert.ToInt32(tmpA[i].Substring(tmpA[i].LastIndexOf("_") + 1, -1 + tmpA[i].Length - tmpA[i].LastIndexOf("_"))));
        _tmpIndizes = ausg;
        //   if (gleichSortieren) Sort(ref a); -> wegen ref ausge..
    }
    public static void Sort<T>(ref List<T> liste)
    {
        List<T> tmp = new List<T>();
        if (_tmpIndizes.Count != liste.Count) return;
        for (int i = 0; i < _tmpIndizes.Count; i++) tmp.Add(liste[_tmpIndizes[i]]);
        liste.Clear();
        liste = tmp;
    }

    public static void Sort(ref List<string> liste)
    {
        Sort<string>(ref liste);
    }

    private static List<int> GetSortedIndizes(List<string> a)
    {
        List<int> ausg = new List<int>();
        List<string> tmpA = new List<string>(a);
        for (int i = 0; i < a.Count; i++) tmpA[i] += "_" + i.ToString(); tmpA.Sort();
        for (int i = 0; i < a.Count; i++) ausg.Add(Convert.ToInt32(tmpA[i].Substring(tmpA[i].LastIndexOf("_") + 1, -1 + tmpA[i].Length - tmpA[i].LastIndexOf("_"))));
        return ausg;
    }
    private static List<T> Zuordnen<T>(List<int> sortedSizes, List<T> liste)
    {
        List<T> tmp = new List<T>();
        if (sortedSizes.Count != liste.Count) return tmp;
        for (int i = 0; i < sortedSizes.Count; i++) tmp.Add(liste[sortedSizes[i]]);
        return tmp;
    }
    #region alterCode
    //private static string ConvertTimeToString(DateTime dt)
    //{
    //    string d = dt.ToShortDateString();
    //    string ausg = String.Empty;
    //    for (int i = 0; i < d.Length; i++)
    //        ausg += (char)d[d.Length - 1 - i];
    //    return ausg;
    //}
    //private static string[] Int2Str(int[] a)
    //{
    //    string[] aNew = new string[a.Length];
    //    for (int i = 0; i < a.Length; i++)
    //        aNew[i] = a.ToString();
    //    return aNew;
    //}
    //private static string[] Date2Str(DateTime[] a)
    //{
    //    string[] aNew = new string[a.Length];
    //    for (int i = 0; i < a.Length; i++)
    //        aNew[i] = ConvertTimeToString(a[i]);
    //    return aNew;
    //}
    //private static void Sort(List<object[]> objektArrays)
    //{
    //    if (objektArrays.Count == 0) return;
    //    if (objektArrays.Count == 1) { objektArrays.Sort(); return; }

    //    int lenght = objektArrays[0].Length;
    //    for (int i = 0; i < objektArrays.Count; i++)
    //        if (objektArrays[i].Length != lenght) throw new Exception("Die Arraygrößen sind nicht gleich!");

    //    List<string> tmpA = new List<string>();

    //    List<List<object>> dieNeuenListen = new List<List<object>>();
    //    for (int i = 0; i < objektArrays.Count; i++)
    //        dieNeuenListen.Add(new List<object>());

    //    List<object> dieerstliste = new List<object>(objektArrays[0]);
    //    for (int i = 0; i < lenght; i++)
    //        tmpA.Add(dieerstliste[i].ToString() + "_" + i.ToString());
    //    tmpA.Sort();

    //    List<int> neuenindexes = new List<int>();
    //    for (int i = 0; i < lenght; i++)
    //        neuenindexes.Add(Convert.ToInt32(tmpA[i].Substring(tmpA[i].LastIndexOf("_") + 1, -1 + tmpA[i].Length - tmpA[i].LastIndexOf("_"))));

    //    for (int i = 0; i < neuenindexes.Count; i++)
    //        for (int j = 0; j < objektArrays.Count; j++)
    //        {
    //            object[] tmp = objektArrays[j];
    //            dieNeuenListen[j].Add(tmp[neuenindexes[i]]);
    //        }

    //    //for (int j = 0; j < length; j++)
    //    //{

    //    //    for (int i = 0; i < lenght; i++)
    //    //    {
    //    //        int index = Convert.ToInt32(tmpA[i].Substring(tmpA[i].LastIndexOf("_") + 1, -1 + tmpA[i].Length - tmpA[i].LastIndexOf("_")));


    //    //        List<object> s = dieNeuenListen[i];
    //    //        object[] origin = objektArrays[i];
    //    //        s.Add(origin[index]);
    //    //    }
    //    //}

    //    //   Array.Sort(a);
    //    for (int i = 0; i < objektArrays.Count; i++)
    //        objektArrays[i] = dieNeuenListen[i].ToArray();
    //}
    //private static void Sort(string[] a, IList<IList<T>> liste2LI)
    //{
    //    int lenght = a.Length;
    //    for (int i = 0; i < liste2LI.Count; i++)
    //        if (liste2LI[i].Count != lenght) return;

    //    List<string> tmpA = new List<string>(a);

    //    List<List<T>> tmpAndere = new List<List<T>>();
    //    for (int i = 0; i < lenght; i++)
    //        tmpAndere.Add(new List<T>());

    //    for (int i = 0; i < lenght; i++)
    //        tmpA[i] += "_" + i.ToString();
    //    tmpA.Sort();

    //    for (int i = 0; i < lenght; i++)
    //    {
    //        int index = Convert.ToInt32(tmpA[i].Substring(tmpA[i].LastIndexOf("_") + 1, -1 + tmpA[i].Length - tmpA[i].LastIndexOf("_")));
    //        List<T> s = tmpAndere[i];
    //        IList<T> origin = liste2LI[i];
    //        s.Add(origin[index]);
    //    }

    //    Array.Sort(a);
    //    liste2LI = tmpAndere.ToArray();
    //}
    //private static void Sort(DateTime[] a, IList<IList<T>> liste2LI)
    //{
    //    Sort(Date2Str(a), liste2LI);
    //    Array.Sort(a);
    //}
    //private static void Sort(int[] a, IList<IList<T>> liste2LI)
    //{
    //    Sort(Int2Str(a), liste2LI);
    //}
    //private static void Sort(string[] a, IList<T> b)
    //{
    //    Sort(a, new List<IList<T>>() { b });
    //}
    //private static void Sort(string[] a, IList<T> b, IList<T> c)
    //{
    //    Sort(a, new List<IList<T>>() { b, c });
    //}
    //private static void Sort(string[] a, IList<T> b, IList<T> c, IList<T> d)
    //{
    //    Sort(a, new List<IList<T>>() { b, c, d });
    //}
    #endregion
}
