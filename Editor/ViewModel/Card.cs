using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Editor.ViewModel
{
    class Card
    {
        public Pokemon.Type Type { get; set; }
        [CanBeNull] public string ImageUrl { get; set; }
        [NotNull] public string Modifier { get; set; } // e.g. 'Surfing', "Team Rocket's", etc.
        public string Pokemon { get; set; }
        public uint HP { get; set; }
        public Pokemon.Type Weakness { get; set; }
        public Pokemon.Type Resistance { get; set; }
        [NotNull] public Pokemon.Move[] Moves { get; set; }
        public uint Level { get; set; }
        [NotNull] public string DexEntry { get; set; }
        public Pokemon.Rarity Rarity { get; set; }

        public string Name => $"{Modifier} {Pokemon}".Trim();
    }
}
