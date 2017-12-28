using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AusgabenManager
{
    public class DescendingComparer : IComparer<long>
    {
        public int Compare(long objA, long objB) // absteigend sortieren
        {
            return String.Compare(objB.ToString(), objA.ToString());
        }
    }
}
