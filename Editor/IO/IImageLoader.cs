using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Result;

namespace Editor.IO
{
    public interface IImageLoader
    {
        IIOResult<string> Load();
    }
}
