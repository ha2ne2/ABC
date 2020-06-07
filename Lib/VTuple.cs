using System.Collections.Generic;

namespace Lib
{
    /// <summary>
    /// ValueTupleのバックポート
    /// (AtCoderのMonoではValueTupleが使えないため）
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public struct VTuple<T1, T2> : System.IComparable<VTuple<T1, T2>>, System.IEquatable<VTuple<T1, T2>>
    {
        public T1 Item1;
        public T2 Item2;

        public T1 First { get { return Item1; } }
        public T2 Second { get { return Item2; } }

        public VTuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        #region override

        public override bool Equals(object obj)
        {
            return obj is VTuple<T1, T2> && Equals((VTuple<T1, T2>)obj);
        }

        public override int GetHashCode()
        {
            int h1 = Item1 != null ? Item1.GetHashCode() : 0;
            int h2 = Item2 != null ? Item2.GetHashCode() : 0;

            return HashHelpers.CombineHashCodes(h1, h2);
        }

        public override string ToString()
        {
            return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ")";
        }

        #endregion

        #region interface implementation

        public bool Equals(VTuple<T1, T2> other)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1)
                && EqualityComparer<T2>.Default.Equals(Item2, other.Item2);
        }

        public int CompareTo(VTuple<T1, T2> other)
        {
            int c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;

            return Comparer<T2>.Default.Compare(Item2, other.Item2);
        }

        #endregion
    }

    public struct VTuple<T1, T2, T3> : System.IComparable<VTuple<T1, T2, T3>>, System.IEquatable<VTuple<T1, T2, T3>>
    {
        public T1 Item1;
        public T2 Item2;
        public T3 Item3;

        public VTuple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        #region override

        public override bool Equals(object obj)
        {
            return obj is VTuple<T1, T2, T3> && Equals((VTuple<T1, T2, T3>)obj);
        }

        public override int GetHashCode()
        {
            int h1 = Item1 != null ? Item1.GetHashCode() : 0;
            int h2 = Item2 != null ? Item2.GetHashCode() : 0;
            int h3 = Item3 != null ? Item3.GetHashCode() : 0;

            return HashHelpers.CombineHashCodes(h1, h2, h3);
        }

        public override string ToString()
        {
            return "(" + Item1?.ToString() + ", "
                + Item2?.ToString() + ", "
                + Item3?.ToString() + ")";
        }

        #endregion

        #region interface implementation

        public bool Equals(VTuple<T1, T2, T3> other)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1)
                && EqualityComparer<T2>.Default.Equals(Item2, other.Item2)
                && EqualityComparer<T3>.Default.Equals(Item3, other.Item3);
        }

        public int CompareTo(VTuple<T1, T2, T3> other)
        {
            int c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;

            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;

            return Comparer<T3>.Default.Compare(Item3, other.Item3);
        }

        #endregion
    }

    public struct VTuple<T1, T2, T3, T4> : System.IComparable<VTuple<T1, T2, T3, T4>>, System.IEquatable<VTuple<T1, T2, T3, T4>>
    {
        public T1 Item1;
        public T2 Item2;
        public T3 Item3;
        public T4 Item4;

        public VTuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }

        #region override

        public override bool Equals(object obj)
        {
            return obj is VTuple<T1, T2, T3, T4> && Equals((VTuple<T1, T2, T3, T4>)obj);
        }

        public override int GetHashCode()
        {
            int h1 = Item1 != null ? Item1.GetHashCode() : 0;
            int h2 = Item2 != null ? Item2.GetHashCode() : 0;
            int h3 = Item3 != null ? Item3.GetHashCode() : 0;
            int h4 = Item3 != null ? Item4.GetHashCode() : 0;

            return HashHelpers.CombineHashCodes(h1, h2, h3, h4);
        }

        public override string ToString()
        {
            return "(" + Item1?.ToString() + ", "
                + Item2?.ToString() + ", "
                + Item3?.ToString() + ", "
                + Item4?.ToString() + ")";
        }

        #endregion

        #region interface implementation

        public bool Equals(VTuple<T1, T2, T3, T4> other)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1)
                && EqualityComparer<T2>.Default.Equals(Item2, other.Item2)
                && EqualityComparer<T3>.Default.Equals(Item3, other.Item3)
                && EqualityComparer<T4>.Default.Equals(Item4, other.Item4);
        }

        public int CompareTo(VTuple<T1, T2, T3, T4> other)
        {
            int c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;

            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;

            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;

            return Comparer<T4>.Default.Compare(Item4, other.Item4);
        }

        #endregion
    }

    public static class HashHelpers
    {
        public static readonly int RandomSeed = new System.Random().Next(int.MinValue, int.MaxValue);

        public static int Combine(int h1, int h2)
        {
            uint rol5 = ((uint)h1 << 5) | ((uint)h1 >> 27);
            return ((int)rol5 + h1) ^ h2;
        }

        public static int CombineHashCodes(int h1, int h2)
        {
            return Combine(Combine(RandomSeed, h1), h2);
        }

        public static int CombineHashCodes(int h1, int h2, int h3)
        {
            return Combine(CombineHashCodes(h1, h2), h3);
        }

        public static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return Combine(CombineHashCodes(h1, h2, h3), h4);
        }
    }
}
