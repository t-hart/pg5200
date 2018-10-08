using System.Collections.Generic;
using Editor.CardProperties;
using JetBrains.Annotations;

namespace Editor.Interfaces
{
    interface IPokemon : IFieldable
    {
        Type Type { get; set; }
        [NotNull] string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        string Pokémon { get; set; }
        Type Weakness { get; set; }
        Type Resistance { get; set; }
        [NotNull] Dictionary<Type, uint> RetreatCost { get; set; }
        IStat Level { get; set; }
        [NotNull] string DexEntry { get; set; }
        Rarity Rarity { get; set; }
    }
}
