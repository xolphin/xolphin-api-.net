using System.Collections.Generic;

namespace XolphinApiDotNet.Models.Response
{
    public class DCV
    {
        public bool status { get; set; }
        public int statusDetail { get; set; }
        public string statusMessage { get; set; }
        public List<DCVDomains> domains { get; set; }
    }
}