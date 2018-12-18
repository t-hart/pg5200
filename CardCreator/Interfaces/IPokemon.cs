using CardCreator.CardProperties;
using CardCreator.ViewModel;
using CardCreator.ViewModel.Interfaces;
using JetBrains.Annotations;

namespace CardCreator.Interfaces
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
