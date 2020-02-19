using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    /// <summary>
    /// ValueTupleのバックポート
    /// (AtCoderのMonoではValueTupleが使えないため）
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public struct VTuple<T1, T2> : IComparable<VTuple<T1, T2>>,  IEquatable<VTuple<T1, T2>>
    {
        public T1 First;
        public T2 Second;

        public VTuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        #region override

        public override bool Equals(object obj)
        {
            return obj is VTuple<T1, T2> && Equals((VTuple<T1, T2>)obj);
        }

        public override int GetHashCode()
        {
            int h1 = First != null ? First.GetHashCode() : 0;
            int h2 = Second != null ? Second.GetHashCode() : 0;

            uint rol5 = ((uint)h1 << 5) | ((uint)h1 >> 27);
            return ((int)rol5 + h1) ^ h2;
        }

        public override string ToString()
        {
            return "(" + First?.ToString() + ", " + Second?.ToString() + ")";
        }

        #endregion

        #region interface implementation

        bool IEquatable<VTuple<T1, T2>>.Equals(VTuple<T1, T2> other)
        {
            return EqualityComparer<T1>.Default.Equals(First, other.First)
                && EqualityComparer<T2>.Default.Equals(Second, other.Second);
        }

        int IComparable<VTuple<T1, T2>>.CompareTo(VTuple<T1, T2> other)
        {
            int c = Comparer<T1>.Default.Compare(First, other.First);
            if (c != 0) return c;
            return Comparer<T2>.Default.Compare(Second, other.Second);
        }

        #endregion

    }
}