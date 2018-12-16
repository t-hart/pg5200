using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Editor.Config;
using Microsoft.Win32;
using Result;

namespace Editor.IO
{
    public class ImageLoader : IImageLoader
    {
        private static readonly string FileTypes = string.Join(";", Image.ValidExtensions.Select(x => $"*{x}"));

        public IIOResult<string> Load() 
        {
            var dialog = new OpenFileDialog { Filter = $"Images({FileTypes})|{FileTypes}" };
            var dialogResult = dialog.ShowDialog();
            if (!(dialogResult.HasValue && dialogResult.Value)) { return IOResult<string>.Cancel(); }

            return IOResult<string>.Complete(Result<string>.Success(dialog.FileName));
        }
    }
}
