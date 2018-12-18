using System.Collections.Generic;
using Editor.CardProperties;
using Editor.ViewModel;
using Editor.ViewModel.Interfaces;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Editor.Interfaces
{
    public interface IPokemon : IFieldable
    {
        IReferenceEnum<Type> Type { get; set; }
        [NotNull] string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        [NotNull] IToggleableEnum<Type> Weakness { get; set; }
        [NotNull] IToggleableEnum<Type> Resistance { get; set; }
        [NotNull] IStat Level { get; set; }
        [NotNull] string DexEntry { get; set; }
        IReferenceEnum<Rarity> Rarity { get; set; }
    }
}
