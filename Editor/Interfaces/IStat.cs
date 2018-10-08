namespace Editor.Interfaces
{
    public interface IStat : IResettable, ICounter
    {
        string Name { get; }
    }
}
