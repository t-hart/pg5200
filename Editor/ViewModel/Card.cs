using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NonEmptyList;

namespace Editor.ViewModel
{
    struct Card
    {
        public Pokémon.Type Type { get; set; }
        [CanBeNull] public string ImageUrl { get; set; }
        [NotNull] public string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        public string Pokémon { get; set; }
        public uint HP { get; set; }
        public Pokémon.Type Weakness { get; set; }
        public Pokémon.Type Resistance { get; set; }
        [NotNull] public NonEmptyList<Pokémon.Move> Moves { get; set; }
        // [CanBeNull] public Pokémon.Ability Ability { get; set; }
        public uint Level { get; set; }
        [NotNull] public string DexEntry { get; set; }
        public Pokémon.Rarity Rarity { get; set; }

        public string Name => $"{Modifier} {Pokémon}".Trim();
    }
}
