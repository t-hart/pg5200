using System;
using JetBrains.Annotations;

namespace StringUtils
{
    public static class StringUtils
    {
        public static string Truncate([NotNull] this string str, uint length) =>
            str.Substring(0, Math.Min((int)length, str.Length));
    }
}
