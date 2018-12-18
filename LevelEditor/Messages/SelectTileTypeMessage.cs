using GalaSoft.MvvmLight.Messaging;
using LevelEditor.Tile;

namespace LevelEditor.Messages
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