using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Responses
{
    public class RequestValidationDomain
    {
        public string domain { get; set; }
        public DCVType dcvType { get; set; }
        public string dcvEmail { get; set; }
        public bool status { get; set; }
        public int statusDetail { get; set; }
        public string statusMessage { get; set; }
    }
}