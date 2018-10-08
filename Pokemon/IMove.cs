using System.Collections.Generic;
using JetBrains.Annotations;

namespace Pokemon
{
    public struct IMove
    {
        [NotNull] string Name { get; set; }
        [NotNull] string Description { get; set; }
        Type Type { get; set; }
        int Damage { get; set; }
        Dictionary<Type, uint> EnergyCost { get; set; }
    }
}
