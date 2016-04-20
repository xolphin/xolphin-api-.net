using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class CSR : Base
    {
        public string Type { get; set; }
        public int Size { get; set; }
        public string Company { get; set; }
        public string CN { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<string> AltNames { get; set; }
    }
}