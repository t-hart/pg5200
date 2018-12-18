using GalaSoft.MvvmLight.Messaging;
using LevelEditor.Tile;

namespace LevelEditor.Messages
{
    public class UpdateTileMessage : MessageBase
    {
        public ITile TileData { get; }

        public UpdateTileMessage(ITile tileData)
        {
            TileData = tileData;
        }
    }
}
