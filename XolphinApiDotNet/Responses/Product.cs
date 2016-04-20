using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Product : Base
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Validation { get; set; }
        public int IncludeDomains { get; set; }
        public int MaxDomains { get; set; }
        public List<ProductPrice> Prices { get; set; }
    }
}