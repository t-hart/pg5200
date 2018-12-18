using LevelEditor.Tile;

namespace LevelEditor.ViewModel
{
    public interface ISerializableToTile
    {
        ITile Serialize();
    }
}