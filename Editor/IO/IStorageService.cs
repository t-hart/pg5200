using Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.IO
{
    public interface IIOService
    {
        IIOResult<string> Save<T>(T o);

        IIOResult<T> Load<T>(T target) where T : class;
    }
}
