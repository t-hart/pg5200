using System.Linq;
using IO.Config;
using Microsoft.Win32;

namespace IO
{
    public class ImageLoader : IImageLoader
    {
        private static readonly string FileTypes = string.Join(";", Image.ValidExtensions.Select(x => $"*{x}"));

        public IIOResult<string> Load() 
        {
            var dialog = new OpenFileDialog { Filter = $"Images({FileTypes})|{FileTypes}" };
            var dialogResult = dialog.ShowDialog();
            if (!(dialogResult.HasValue && dialogResult.Value)) { return IOResult<string>.Cancel(); }

            return IOResult<string>.Complete(Result.Result<string>.Success(dialog.FileName));
        }
    }
}
