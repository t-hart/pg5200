using LevelEditor.Tile;

namespace LevelEditor.ViewModel
{
    public class Tile : ITile
    {
        public uint X { get; }
        public uint Y { get; }
        public TileType Type { get; }

        public Tile(uint x, uint y, TileType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public ITile Serialize() => this;
    }
}