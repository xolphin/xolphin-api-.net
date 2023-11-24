using Newtonsoft.Json;
using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Base
    {
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public dynamic page = 0;
        public int Page   // property
        {
            get
            {
                return page;
            }   // get method
            set
            {
                page = value;
            }  // set method
        }
        public int Limit { get; set; }
        public int Pages { get; set; }
        public int Total { get; set; }

        public dynamic embedded;
        public dynamic _embedded{
            get
            {
                return Embedded;
            }
            set
            {
                string json = value.ToString();
                var embeddedDynamic = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
                Embedded = embeddedDynamic;
            }
        }
        public dynamic Links { get; set; }
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