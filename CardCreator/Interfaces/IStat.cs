namespace CardCreator.Interfaces
{
    public interface IStat : IResettable, ICounter
    {
        string Name { get; }
    }
}
