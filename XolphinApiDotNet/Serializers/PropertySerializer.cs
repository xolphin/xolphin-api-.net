using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XolphinApiDotNet.Serializers
{
    class PropertySerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer;

        public PropertySerializer()
        {
            ContentType = "application/json";
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        public PropertySerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = "application/json";
            _serializer = serializer;
        }

        public string Serialize(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowerCaseResolver()
            };
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        public string DateFormat { get; set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string ContentType { get; set; }
    }

    public class LowerCaseResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            if (propertyName.Length == 1 || propertyName.All(c => Char.IsUpper(c)))
            {
                return propertyName.ToLowerInvariant();
            }
            else
            {
                StringBuilder builder = new StringBuilder().Append(Char.ToLowerInvariant(propertyName[0]));
                for (int i = 1; i < propertyName.Length; i++)
                {
                    char propertySymbol = propertyName[i];
                    bool isAcronym = Char.IsUpper(propertySymbol) && ((i + 1 < propertyName.Length) && Char.IsUpper(propertyName[i + 1]));
                    builder.Append(isAcronym ? Char.ToLowerInvariant(propertySymbol) : propertySymbol);
                }
                return builder.ToString();
            }
        }
    }
}