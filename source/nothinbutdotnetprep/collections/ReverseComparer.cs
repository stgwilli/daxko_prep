using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ReverseComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return -(x.CompareTo(y));
        }
    }
}