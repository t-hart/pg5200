using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Result
{
    public interface IResult<T> where T : class
    {
        Exception Err { get; }
        T Ok { get; }
        bool IsOk { get; }
        bool IsError { get; }
    }
}
