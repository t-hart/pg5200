using JetBrains.Annotations;

namespace Editor.Interfaces
{
    public interface IFieldable : IResettable
    {
        IStat HP { get; set; }
        string Name { get; set; }
        [CanBeNull] string ImageUrl { get; set; }
    }
}
