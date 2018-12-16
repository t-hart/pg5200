using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace IO.Config
{
    public static class Image
    {
        private enum Extensions
        {
            Jpeg,
            Jpg,
            Png
        }
        public static IEnumerable<string> ValidExtensions { get; }= Enum.GetNames(typeof(Extensions)).Select(x => $".{x.ToLower()}");

        public static bool IsValidImageFile([NotNull] string path) =>
            ValidExtensions.Any(x => x == (Path.GetExtension(path).ToLower()));

    }
}
