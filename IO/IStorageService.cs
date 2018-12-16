namespace IO
{
    public interface IStorageService
    {
        IIOResult<string> Save<T>(T o);

        IIOResult<T> Load<T>(T target) where T : class;
    }
}
