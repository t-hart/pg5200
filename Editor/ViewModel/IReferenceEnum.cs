using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Editor.ViewModel
{
    public interface IReferenceEnum<T> where T : Enum
    {
        [JsonConverter(typeof(StringEnumConverter))]
        T Value { get; set; }
    }
}
