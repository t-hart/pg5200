using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Editor.ViewModel.Interfaces
{
    public interface IToggleableEnum<T> where T : Enum
    {
        bool IsActive { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        T Current { get; set; }
    }
}
