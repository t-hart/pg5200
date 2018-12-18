using LevelEditor.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LevelEditor.Tile
{
    public interface ITile : ISerializableToTile
    {
        uint X { get; }
        uint Y { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        TileType Type { get; }
    }
}
