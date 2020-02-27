using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public struct Mint : IComparable<Mint>,  IEquatable<Mint>
    {
        public static readonly long MOD = (long)1e9 + 7;

        /// <summary>
        /// 0以上MOD未満の整数
        /// </summary>
        public long Value;

        #region constructor

        public Mint(long val)
        {
            Value = val % MOD;
            if (Value < 0) Value += MOD;
        }

        /// <summary>
        /// 通常のコンストラクタでは、valに対して%オペレータとif文を使って確実にMODを取る。
        /// 場合によってはより軽量の処理でMODが取れる場合があるため、上記処理を省きたい時がある。
        /// このメソッドでは引数をMODを取り終えたものとしてMintのインスタンスを作成する。
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static Mint Ctor(long val)
        {
            return new Mint() { Value = val };
        }

        #endregion

        #region operator overload / override

        public static Mint operator +(Mint a, Mint b)
        {
            long res = a.Value + b.Value;
            if (res > MOD) res -= MOD;
            return Ctor(res);
        }
        public static Mint operator -(Mint a, Mint b)
        {
            long res = a.Value - b.Value;
            if (res < 0) res += MOD;
            return Ctor(res);
        }

        public static Mint operator *(Mint a, Mint b)
        {
            long res = a.Value * b.Value;
            if (res > MOD) res %= MOD;
            return Ctor(res);
        }

        public static Mint operator /(Mint a, Mint b)
        {
            return a * Inv(b);
        }

        public override bool Equals(object obj)
        {
            return obj is Mint mint && Value == mint.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator Mint(long a) { return new Mint(a); }
        public static explicit operator long(Mint a) { return a.Value; }

        #endregion

        #region public method

        public static Mint Pow(Mint a, long n)
        {
            if (n == 0) return new Mint(1);
            Mint b = Pow(a, n >> 1);
            b *= b;
            if ((n & 1) == 1) b *= a;
            return b;
        }

        public static Mint Inv(Mint n)
        {
            long a = n.Value;
            long b = MOD;

            long x = 1;
            long u = 0;
            while (b != 0)
            {
                long k = a / b;
                long _x = u;
                u = x - k * u;
                x = _x;

                long _a = a;
                a = b;
                b = _a - (k * b);
            }

            return new Mint(x);
        }

        #endregion

        #region interface implementation

        /// <summary>
        /// 構造体の場合は同値性判断をするEqualsが自動で実装されるが、
        /// リフレクションを用いた実装のためIEquatableを自分で実装したほうが良い。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool IEquatable<Mint>.Equals(Mint other)
        {
            return Value == other.Value;
        }

        int IComparable<Mint>.CompareTo(Mint other)
        {
            return Comparer<Mint>.Default.Compare(Value, other.Value);
        }

        #endregion
    }
}