namespace CardCreator.Interfaces
{
    public interface ICounter
    {
        uint Value { get; set; }
        void Increment();
        void Decrement();
    }
}
