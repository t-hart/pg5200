using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CardCreator.ViewModel
{
    public interface IReferenceEnum<T> where T : Enum
    {
        [JsonConverter(typeof(StringEnumConverter))]
        T Value { get; set; }
    }
}
