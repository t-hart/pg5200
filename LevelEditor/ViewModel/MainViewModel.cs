using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IO;
using JetBrains.Annotations;
using LevelEditor.Messages;
using LevelEditor.Tile;

namespace LevelEditor.ViewModel
{
    [UsedImplicitly]
    public class MainViewModel : ViewModelBase
    {
        public const uint NumTilesX = 20;
        public const uint NumTilesY = NumTilesX;
        public const uint TileWidth = 60;
        public const uint TileHeight = TileWidth;

        public uint MapWidth => NumTilesX * TileWidth;
        public uint MapHeight => NumTilesY * TileHeight;

        [NotNull]
        public IEnumerable<ButtonViewModel> Buttons { get; } = new (string text, TileType type)[]{
                ("Void", TileType.Void),
                ("Grass", TileType.Grass),
                ("Flowers", TileType.Flowers),
                ("Water", TileType.Water),
                ("Soil", TileType.Soil)
            }.Select(t => new ButtonViewModel(t.text, t.type));

        [NotNull] public IStorageService Storage { get; } = new Json();
        [NotNull] public RelayCommand SaveCommand { get; }
        [NotNull] public RelayCommand LoadCommand { get; }
        [NotNull] public RelayCommand ClearCommand { get; }

        public IEnumerable<TileViewModel> Points => Tiles.Values;

        [NotNull]
        private Dictionary<(uint, uint), TileViewModel> Tiles { get; } =
            Enumerable.Range(0, (int)NumTilesX).SelectMany(x => Enumerable.Range(0, (int)NumTilesY).Select(y => ((uint)x, (uint)y)))
                .ToDictionary(p => p, ((uint x, uint y) p) => new TileViewModel(p.x * TileWidth, p.y * TileHeight, TileWidth, TileHeight, TileType.Void, TileProvider.Instance));

        public MainViewModel()
        {
            ClearCommand = new RelayCommand(() => MessengerInstance.Send(new SetTileTypeMessage(TileType.Void)));
            SaveCommand = new RelayCommand(() => Utils.PerformIO(() => Storage.Save(Tiles.Values.Select(x => x.Serialize()))));
            LoadCommand = new RelayCommand(() =>
            {
                var tiles = new List<Tile>();
                Utils.PerformIO(() => Storage.Load(tiles));

                foreach (var tile in tiles)
                {
                    MessengerInstance.Send(new UpdateTileMessage(tile));
                }
            });
        }

        public class ButtonViewModel : ViewModelBase
        {

            public string Text { get; set; }
            public RelayCommand Command { get; set; }
            public TileType TileType { get; }

            public ButtonViewModel(string text, TileType type)
            {
                TileType = type;
                Text = text;
                Command = new RelayCommand(() => MessengerInstance.Send(new SelectTileTypeMessage(TileType)));
            }

        }

    }

    public class SetTileTypeMessage
    {
        public TileType TileType { get; }
        public SetTileTypeMessage(TileType tileType)
        {
            TileType = tileType;
        }
    }
}