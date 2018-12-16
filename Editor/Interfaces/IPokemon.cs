using System.Collections.Generic;
using Editor.CardProperties;
using Editor.ViewModel;
using Editor.ViewModel.Interfaces;
using JetBrains.Annotations;

namespace Editor.Interfaces
{
    public interface IPokemon : IFieldable
    {
        Type Type { get; set; }
        [NotNull] string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        [NotNull] IToggleableEnum<Type> Weakness { get; set; }
        [NotNull] IToggleableEnum<Type> Resistance { get; set; }
        [NotNull] IStat Level { get; set; }
        [NotNull] string DexEntry { get; set; }
        Rarity Rarity { get; set; }
    }
}
