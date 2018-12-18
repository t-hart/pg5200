using LevelEditor.Tile;

namespace LevelEditor.Messages
{
    public class SetTileTypeMessage
    {
        public TileType TileType { get; }
        public SetTileTypeMessage(TileType tileType)
        {
            TileType = tileType;
        }
    }
}