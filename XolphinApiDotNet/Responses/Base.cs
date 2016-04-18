using Newtonsoft.Json;
using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Base
    {
        public string message { get; set; }
        public Dictionary<string, List<string>> errors { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int pages { get; set; }
        public int total { get; set; }
        public dynamic _embedded { get; set; }

        public bool isError()
        {
            return !string.IsNullOrEmpty(message);
        }

        protected T GetEmbedded<T>(string key)
        {
            // Quite hacky, but haven't found a better way how to deal with dynamics
            var entity = JsonConvert.SerializeObject(_embedded[key]);
            return JsonConvert.DeserializeObject<T>(entity);
        }

        protected IEnumerable<T> GetEmbeddedEnumerable<T>(string key)
        {
            foreach (var entity in _embedded[key])
            {
                // Quite hacky, but haven't found a better way how to deal with dynamics
                var obj = JsonConvert.SerializeObject(entity);
                yield return JsonConvert.DeserializeObject<T>(obj);
            }
        }
    }
}