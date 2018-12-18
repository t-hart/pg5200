using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UI.Tile
{
    public interface ITile
    {
        uint X { get; }
        uint Y { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        TileType Type { get; set; }
    }
}
