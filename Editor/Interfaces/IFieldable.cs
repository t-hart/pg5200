using JetBrains.Annotations;

namespace Editor.Interfaces
{
    public interface IFieldable : IResettable
    {
        [NotNull] IStat HP { get; set; }
        [NotNull] string Name { get; set; }
        [NotNull] string ImagePath { get; set; }
    }
}
