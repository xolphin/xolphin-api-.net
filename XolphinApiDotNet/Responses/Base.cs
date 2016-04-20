using Newtonsoft.Json;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Base
    {
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int Pages { get; set; }
        public int Total { get; set; }
        [JsonProperty("_embedded")]
        public dynamic Embedded { get; set; }

        public bool isError()
        {
            return !string.IsNullOrEmpty(Message);
        }

        protected T GetEmbedded<T>(string key)
        {
            // Quite hacky, but haven't found a better way how to deal with dynamics
            var entity = JsonConvert.SerializeObject(Embedded[key]);
            return JsonConvert.DeserializeObject<T>(entity);
        }

        protected IEnumerable<T> GetEmbeddedEnumerable<T>(string key)
        {
            foreach (var entity in Embedded[key])
            {
                // Quite hacky, but haven't found a better way how to deal with dynamics
                var obj = JsonConvert.SerializeObject(entity);
                yield return JsonConvert.DeserializeObject<T>(obj);
            }
        }
    }
}