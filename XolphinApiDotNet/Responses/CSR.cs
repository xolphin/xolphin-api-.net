using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class CSR : Base
    {
        public string type { get; set; }
        public int size { get; set; }
        public string company { get; set; }
        public string cn { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public List<string> altNames { get; set; }
    }
}