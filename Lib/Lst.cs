using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    /// <summary>
    /// ＊＊あくまで競プロ用＊＊
    /// 添字にlongを使えるListのラッパークラス。
    /// インデクサをオーバーライドし、実行時に添字をintへダウンキャストします。
    /// キャストに失敗した場合は InvalidCastException を投げます。
    /// （アンダーフローのチェックをしないビルド設定になっている場合、例外を投げません。
    /// 　VisualStudioのデフォルトの設定ではチェックをしません。）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Lst<T> : List<T>
    {
        public T this[long i]
        {
            set
            {
                base[(int)i] = value;
            }

            get
            {
                return base[(int)i];
            }
        }
    }

    //public class Sample
    //{
    //    public void Hoge()
    //    {
    //        long index = 3;

    //        // C#は配列はlong添字を許す
    //        long[] array = new long[3];
    //        var val1 = array[index];

    //        // C#はリストはlong添字を許さない
    //        List<long> list = new List<long>();
    //        var val2 = list[index];

    //        // yay
    //        Lst<long> lst = new Lst<long>();
    //        var val3 = lst[index];
    //    }
    //}
}
