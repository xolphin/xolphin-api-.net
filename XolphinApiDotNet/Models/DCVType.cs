using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace XolphinApiDotNet.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DCVType
    {
        EMAIL,
        FILE,
        DNS
    }
}