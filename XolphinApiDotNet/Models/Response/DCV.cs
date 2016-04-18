using System.Collections.Generic;

namespace XolphinApiDotNet.Models.Response
{
    public class Dcv
    {
        public bool status { get; set; }
        public int statusDetail { get; set; }
        public string statusMessage { get; set; }
        public List<DcvDomains> domains { get; set; }
    }
}