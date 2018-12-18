using JetBrains.Annotations;

namespace CardCreator.Interfaces
{
    public interface IFieldable : IResettable
    {
        [NotNull] IStat HP { get; set; }
        [NotNull] string Name { get; set; }
        [NotNull] string ImagePath { get; set; }
    }
}
