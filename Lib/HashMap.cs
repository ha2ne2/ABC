using System;

namespace Lib
{
    public class HashMap<K, V> : System.Collections.Generic.Dictionary<K, V>
    {
        private V DefaultValue;
        private static Func<V> CreateInstance =
            System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();

        public HashMap() { }
        public HashMap(V defaultValue)
        {
            DefaultValue = defaultValue;
        }
        new public V this[K i]
        {
            get
            {
                V v;
                if (TryGetValue(i, out v))
                {
                    return v;
                }
                else
                {
                    return base[i] = DefaultValue != null ? DefaultValue : CreateInstance();
                }
            }
            set { base[i] = value; }
        }
    }
}
