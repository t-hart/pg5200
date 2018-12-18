using JetBrains.Annotations;

namespace CardCreator.Interfaces
{
    public interface IMove : IResettable
    {
        [NotNull] string Name { get; set; }
        [NotNull] string Description { get; set; }
        [NotNull] IStat Damage { get; set; }
    }
}
