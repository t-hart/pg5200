using System.Collections.Generic;
using Editor.CardProperties;
using Editor.ViewModel;
using JetBrains.Annotations;

namespace Editor.Interfaces
{
    public interface IPokemon : IFieldable
    {
        Type Type { get; set; }
        [NotNull] string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        ToggleableEnum<Type> Weakness { get; set; }
        ToggleableEnum<Type> Resistance { get; set; }
        IStat Level { get; set; }
        [NotNull] string DexEntry { get; set; }
        Rarity Rarity { get; set; }
    }
}
