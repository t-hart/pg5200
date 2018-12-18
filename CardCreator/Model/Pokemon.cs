using System.Collections.Generic;
using CardCreator.Interfaces;
using CardCreator.ViewModel;
using CardCreator.ViewModel.Interfaces;
using JetBrains.Annotations;
using StringUtils;
using Type = CardCreator.CardProperties.Type;
using Rarity = CardCreator.CardProperties.Rarity;

namespace CardCreator.Model
{
    class Pokemon : IPokemon
    {
        public IResettable Reset()
        {
            ImagePath = string.Empty;
            Modifier = string.Empty;
            Name = string.Empty;
            DexEntry = string.Empty;
            Weakness.Value = CardProperties.Type.Colorless;
            Weakness.IsActive = false;
            Resistance.Value = CardProperties.Type.Colorless;
            Resistance.IsActive = false;
            HP.Reset();
            Level.Reset();
            Type.Value = CardProperties.Type.Colorless;
            Rarity.Value = CardProperties.Rarity.Common;

            return this;
        }

        public IStat HP { get; set; }
        public string ImagePath { get; set; }
        public IReferenceEnum<Type> Type { get; set; }

        private string _modifier = "";
        public string Modifier
        {
            get => _modifier;
            set { if (value != _modifier) { _modifier = value.Truncate(Config.General.MaxModifierLength); } }
        }

        [NotNull] private string _name = "";

        public string Name
        {
            get => _name;
            set { if (value != _name) { _name = value.Truncate(Config.General.MaxNameLength); } }
        }

        public IToggleableEnum<Type> Weakness { get; set; }
        public IToggleableEnum<Type> Resistance { get; set; }
        public IStat Level { get; set; }

        private string _dexEntry = "";
        public string DexEntry
        {
            get => _dexEntry;
            set { if (value != _dexEntry) { _dexEntry = value.Truncate(Config.General.MaxDexEntryLength); } }
        }

        public IReferenceEnum<Rarity> Rarity { get; set; }

        public Pokemon(
            [NotNull] string modifier = "",
            [NotNull] string name = "",
             uint hp = 10,
             uint level = 5,
            [NotNull] string imageUrl = "",
            Type type = CardProperties.Type.Colorless,
            Type? weakness = null,
            Type? resistance = null,
            Dictionary<Type, uint> retreatCost = null,
            [NotNull] string dexEntry = "",
            Rarity rarity = CardProperties.Rarity.Common
        )
        {
            Modifier = modifier;
            Name = name;
            ImagePath = imageUrl;
            HP = new Stat.HP(hp);
            Level = new Stat.Level(level);
            Type = new ReferenceEnum<Type>(type);
            Weakness = new ToggleableEnum<Type>(weakness ?? 0, weakness != null);
            Resistance = new ToggleableEnum<Type>(resistance ?? 0, resistance != null);
            DexEntry = dexEntry;
            Rarity = new ReferenceEnum<Rarity>(rarity);
        }
    }
}
