using JetBrains.Annotations;
using NonEmptyList;
using Pokemon;

namespace Editor.ViewModel
{
    interface IPokemon : IFieldable
    {
//        Type<IType> Type { get; set; }
        TypeEnum Type { get; set; }
        [NotNull] string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        string Pokémon { get; set; }
        Type<IType> Weakness { get; set; }
        Type<IType> Resistance { get; set; }
        [NotNull] NonEmptyList<IMove> Moves { get; set; }
        // [CanBeNull] public Pokémon.Ability Ability { get; set; }
        uint Level { get; set; }
        [NotNull] string DexEntry { get; set; }
        Rarity Rarity { get; set; }

//        string Name => $"{Modifier} {Pokémon}".Trim();
    }
}
