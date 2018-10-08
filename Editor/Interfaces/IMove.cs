using System.Collections.Generic;
using Editor.CardProperties;
using JetBrains.Annotations;

namespace Editor.Interfaces
{
    public struct IMove
    {
        [NotNull] string Name { get; set; }
        [NotNull] string Description { get; set; }
        Type Type { get; set; }
        IStat Damage { get; set; }
        Dictionary<Type, uint> EnergyCost { get; set; }
    }
}
