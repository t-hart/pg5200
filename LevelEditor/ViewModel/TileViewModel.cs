using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LevelEditor.Messages;
using LevelEditor.Tile;

namespace LevelEditor.ViewModel
{
    public class TileViewModel : ViewModelBase, ITile
    {
        public uint X { get; }
        public uint Y { get; }
        public TileType Type { get; set; }
        public uint TileWidth { get; set; }
        public uint TileHeight { get; set; }
        public RelayCommand MouseEnterCommand { get; }
        public RelayCommand MouseDownCommand { get; }
        public ITileProvider TileProvider { get; }
        private TileType _selectedType;
        public CroppedBitmap Tile { get; set; }

        public TileViewModel(uint x, uint y, uint tileWidth, uint tileHeight, TileType type, ITileProvider tileProvider)
        {
            MessengerInstance.Register<SelectTileTypeMessage>(this, msg => _selectedType = msg.NewTile);
            MessengerInstance.Register<SetTileTypeMessage>(this, msg =>
            {
                _selectedType = msg.TileType;
                DrawTile();
            });
            MessengerInstance.Register<UpdateTileMessage>(this, msg =>
            {
                if (X == msg.TileData.X * TileWidth && Y == msg.TileData.Y * TileHeight)
                {
                    _selectedType = msg.TileData.Type;
                    DrawTile();
                }
            });

            X = x;
            Y = y;
            Type = type;
            _selectedType = TileType.Void;
            Tile = null;
            TileProvider = tileProvider;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            MouseDownCommand = new RelayCommand(DrawTile);
            MouseEnterCommand = new RelayCommand(() =>
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    DrawTile();
                }
            });

            void DrawTile()
            {
                Type = _selectedType;
                Tile = TileProvider.Get(Type);
                RaisePropertyChanged("");
            }
        }

        public ITile Serialize() => new Tile(X / TileWidth, Y / TileHeight, Type);
    }
}