using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;
using UI.Tile;

namespace UI.ViewModel
{
    public class SelectTileTypeMessage : MessageBase
    {
        public TileType NewTile { get; }

        public SelectTileTypeMessage(TileType newTile)
        {
            NewTile = newTile;
        }

    }
}