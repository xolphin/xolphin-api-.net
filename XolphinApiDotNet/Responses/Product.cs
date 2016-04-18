using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Product : Base
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string validation { get; set; }
        public int includeDomains { get; set; }
        public int maxDomains { get; set; }
        public List<ProductPrice> prices { get; set; }
    }
}