using System.Windows.Media.Imaging;

namespace LevelEditor.Tile
{
    public interface ITileProvider
    {
        CroppedBitmap Get(TileType type);
    }
}
