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
    class Pokemon : IPokemon
    {
        public IResettable Reset()
        {
            throw new NotImplementedException();
        }

        private IStat _hp = Stat.HP(10);
        public IStat HP { get; set; }
        public string ImagePath { get; set; }
        public Type Type { get; set; }

        private string _modifier = "";
        public string Modifier
        {
            get => _modifier;
            set { if (value != _modifier) { _modifier = value.Truncate(Config.MaxModifierLength); } }
        }

        [NotNull] private string _name = "";

        [NotNull]
        public string Name
        {
            get => _name;
            set { if (value != _name) { _name = value.Truncate(Config.MaxNameLength); } }
        }

        [CanBeNull] public ToggleableEnum<Type> Weakness { get; set; }
        [CanBeNull] public ToggleableEnum<Type> Resistance { get; set; }
        [CanBeNull] public Dictionary<Type, uint> RetreatCost { get; set; }
        public IStat Level { get; set; }

        private string _dexEntry = "";
        public string DexEntry
        {
            get => _dexEntry;
            set { if (value != _dexEntry) { _dexEntry = value.Truncate(Config.MaxDexEntryLength); } }
        }
        
        public Rarity Rarity { get; set; }

        public Pokemon(
            [NotNull] string modifier = "",
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
            ImagePath = imageUrl;
            HP = hp ?? Stat.HP(10);
            Level = level ?? Stat.Level();
            Type = type;
            Weakness = new ToggleableEnum<Type>(weakness ?? 0, weakness != null);
            Resistance = new ToggleableEnum<Type>(resistance ?? 0, resistance != null);
            RetreatCost = retreatCost;
            DexEntry = dexEntry;
            Rarity = rarity;
        }
    }
}
