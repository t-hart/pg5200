using System;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;
using Result;
using Formatting = Newtonsoft.Json.Formatting;

namespace IO
{
    public class Json : IStorageService
    {
        private static IResult<T> Operate<T>(Func<T> f) where T : class
        {
            try
            {
                return Result<T>.Success(f());
            }
            catch (Exception e)
            {
                return Result<T>.Failure(e);
            }
        }

        private static IResult<string> Save<T>(T o, string path) =>
            Operate(() =>
                {
                    using (var writer = new StreamWriter(path))
                    {
                        writer.Write((string) JsonConvert.SerializeObject(o, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                DateFormatString = "yyyy-MM-ddTHH:mm:sszzz",
                                NullValueHandling = NullValueHandling.Ignore,
                            }));
                    }

                    return path;
                }
            );

        private static IResult<T> Load<T>(T target, string path) where T : class =>
            Operate(() =>
            {
                using (var reader = new StreamReader(path))
                {
                    JsonConvert.PopulateObject(reader.ReadToEnd(), target);
                }

                return target;
            });

        public IIOResult<string> Save<T>(T o)
        {
            var dialog = new SaveFileDialog {Filter = "JSON (*.json)|*.json"};
            var result = dialog.ShowDialog();
            return result.HasValue && result.Value
                ? IOResult<string>.Complete(Save(o, dialog.FileName))
                : IOResult<string>.Cancel();
        }

        public IIOResult<T> Load<T>(T target) where T : class
        {
            var dialog = new OpenFileDialog {Filter = "JSON (*.json)|*.json"};
            var result = dialog.ShowDialog();
            return result.HasValue && result.Value
                ? IOResult<T>.Complete(Load(target, dialog.FileName))
                : IOResult<T>.Cancel();
        }
    }
}
