using System;
using System.Collections.Generic;
using System.Text;

namespace AppLauncher
{
    class Utils
    {
        public static String[] MergeArrays(String[] a, String[] b)
        {
            String[] mergedArray = new String[a.Length + b.Length];
            a.CopyTo(mergedArray, 0);
            b.CopyTo(mergedArray, a.Length);
            return mergedArray;
        }
    }
}
