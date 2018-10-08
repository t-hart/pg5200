using System.Collections.Generic;
using JetBrains.Annotations;
using Pokemon;

namespace Editor.ViewModel
{
    interface IPokemon : IFieldable
    {
        Type Type { get; set; }
        [NotNull] string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        string Pokémon { get; set; }
        Type Weakness { get; set; }
        Type Resistance { get; set; }
        [NotNull] Dictionary<Type, uint> RetreatCost { get; set; }
        uint Level { get; set; }
        [NotNull] string DexEntry { get; set; }
        Rarity Rarity { get; set; }

//        string Name => $"{Modifier} {Pokémon}".Trim();
    }
}
