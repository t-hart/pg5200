using System;
using Result;

namespace IO.IO
{
    class IOResult<T> : IIOResult<T> where T : class
    {
        public IResult<T> Result { get; }
        public bool Completed { get; }

        private IOResult(IResult<T> result, bool completed)
        {
            Result = result;
            Completed = completed;
        }

        public static IIOResult<T> Cancel() => new IOResult<T>(null, false);
        public static IIOResult<T> Complete(IResult<T> result) => new IOResult<T>(result, true);

        public Exception Err => Result.Err;
        public T Ok => Result.Ok;
        public bool IsOk => Completed && Result.IsOk;
        public bool IsError => Completed && Result.IsError;
    }
}
