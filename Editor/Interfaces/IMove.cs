using System.Collections.Generic;
using Editor.CardProperties;
using JetBrains.Annotations;

namespace Editor.Interfaces
{
    public interface IMove : IResettable
    {
        [NotNull] string Name { get; set; }
        [NotNull] string Description { get; set; }
        [NotNull] IStat Damage { get; set; }
    }
}
