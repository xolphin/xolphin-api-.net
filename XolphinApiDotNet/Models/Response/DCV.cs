using System.Collections.Generic;

namespace XolphinApiDotNet.Models.Response
{
    public class DCV
    {
        public bool Status { get; set; }
        public int StatusDetail { get; set; }
        public string StatusMessage { get; set; }
        public List<DCVDomains> Domains { get; set; }
    }
}