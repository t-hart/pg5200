using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Result;

namespace Editor.IO
{
    public interface IIOResult<T> : IResult<T> where T : class
    {
        IResult<T> Result { get; }
        bool Completed { get; }
    }
}
