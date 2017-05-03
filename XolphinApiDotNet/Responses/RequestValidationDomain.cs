using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Responses
{
    public class RequestValidationDomain
    {
        public string Domain { get; set; }
        public DCVType DCVType { get; set; }
        public string DCVEmail { get; set; }
        public bool Status { get; set; }
        public int StatusDetail { get; set; }
        public string StatusMessage { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
    }
}