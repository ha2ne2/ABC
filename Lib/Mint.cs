using System.Collections.Generic;

namespace Lib
{
    public struct Mint : System.IComparable<Mint>, System.IEquatable<Mint>
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
        /// 通常のコンストラクタでは、valに対して%オペレータとif文を使って確実に余りを求める。
        /// しかし場合によってはその値をより軽量の処理で算出出来る場合があるため、上記処理を省きたい時がある。
        /// このメソッドでは引数を既に余りを求め終えた数としてMintのインスタンスを作成する。
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
            return obj is Mint && Value == ((Mint)obj).Value;
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

        /// <summary>
        /// 定数MODを法とした時のnの逆元を返します。
        /// 拡張ユークリッド互除法の行列による非再帰実装です。
        /// 理解するためには、1次不定方程式における次の定理の証明の理解が必要です。
        /// ax+by = 1 ⇔ aとbは互いに素
        /// ax+by = cが整数解を持つ ⇔ cはgcd(a,b)の倍数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Mint Inv(Mint n)
        {
            long a = n.Value;
            long b = MOD;

            // x,uの初期値は単位行列の一列目
            long x = 1;
            long u = 0;
            while (b != 0)
            {
                long k = a / b;

                // 行列の累積積の一列目
                long _x = x;
                x = u;
                u = _x - (k * u);

                // 現在の係数（Euclid）
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
        /// それはリフレクションを用いた実装なのでIEquatableを自分で実装したほうが早い。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Mint other)
        {
            return Value == other.Value;
        }

        public int CompareTo(Mint other)
        {
            return Comparer<long>.Default.Compare(Value, other.Value);
        }

        #endregion
    }
}