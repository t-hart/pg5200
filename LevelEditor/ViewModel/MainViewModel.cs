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

        public uint MapWidth => Config.Map.NumTilesX * Config.Map.TileWidth;
        public uint MapHeight => Config.Map.NumTilesY * Config.Map.TileHeight;

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
            Enumerable.Range(0, (int)Config.Map.NumTilesX).SelectMany(
                    x => Enumerable.Range(0, (int)Config.Map.NumTilesY).Select(
                        y => ((uint)x, (uint)y)))
                .ToDictionary(p => p, ((uint x, uint y) p) => new TileViewModel(p.x * Config.Map.TileWidth, p.y * Config.Map.TileHeight, Config.Map.TileWidth, Config.Map.TileHeight, TileType.Void, TileProvider.Instance));

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
}