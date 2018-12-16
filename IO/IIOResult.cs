using Result;

namespace IO
{
    public interface IIOResult<T> : IResult<T> where T : class
    {
        IResult<T> Result { get; }
        bool Completed { get; }
    }
}
