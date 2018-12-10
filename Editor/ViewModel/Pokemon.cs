using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.CardProperties;
using Editor.Interfaces;
using JetBrains.Annotations;
using StringUtils;
using Type = Editor.CardProperties.Type;

namespace Editor.ViewModel
{
    class Pokemon : IPokemon, IResettable
    {
        public IResettable Reset()
        {
            throw new NotImplementedException();
        }

        public IStat HP { get; set; }
        public string ImageUrl { get; set; }
        public Type Type { get; set; }
        public string Modifier { get; set; }
        [NotNull] private string _name = "";

        [NotNull] public string Name
        {
            get => _name;
            set
            {
                if (value == _name) { return; }

                _name = value.Truncate(Config.MaxNameLength);
            }
        }

        [CanBeNull] public Type? Weakness { get; set; }
        [CanBeNull] public Type? Resistance { get; set; }
        [CanBeNull] public Dictionary<Type, uint> RetreatCost { get; set; }
        public IStat Level { get; set; }
        public string DexEntry { get; set; }
        public Rarity Rarity { get; set; }

        public Pokemon([NotNull] string modifier = "",
            [NotNull] string name = "",
            [CanBeNull] IStat hp = null,
            [CanBeNull] IStat level = null,
            [NotNull] string imageUrl = "",
            Type type = Type.Colorless,
            Type? weakness = null,
            Type? resistance = null,
            Dictionary<Type, uint> retreatCost = null,
            [NotNull] string dexEntry = "",
            Rarity rarity = Rarity.Common
        )
        {
            Modifier = modifier;
            Name = name;
            ImageUrl = imageUrl;
            HP = hp ?? Stat.HP(10);
            Level = level ?? Stat.Level();
            Type = type;
            Weakness = weakness;
            Resistance = resistance;
            RetreatCost = retreatCost;
            DexEntry = dexEntry;
            Rarity = rarity;
        }
    }
}