using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace StringUtils
{
    public static class StringUtils
    {
        public static string Truncate([NotNull] this string str, uint length) =>
            str.Substring(0, Math.Min((int)length, str.Length));
    }
}
