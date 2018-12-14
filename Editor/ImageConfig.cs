using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Editor
{
    public static class ImageConfig
    {
        private enum ImageFileExtension
        {
            Jpeg,
            Jpg,
            Png
        }
        public static IEnumerable<string> ValidExtensions { get; }= Enum.GetNames(typeof(ImageFileExtension)).Select(x => $".{x.ToLower()}");

        public static bool IsValidImageFile([NotNull] string path) =>
            ValidExtensions.Any(x => x == (Path.GetExtension(path).ToLower()));

    }
}
