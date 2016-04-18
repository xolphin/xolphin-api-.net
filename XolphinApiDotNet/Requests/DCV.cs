using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class DCV
    {
        public string domain { get; private set; }
        public DCVType dcvType { get; private set; }
        public string email { get; private set; }

        public DCV(string domain, DCVType dcvType, string email)
        {
            this.domain = domain;
            this.dcvType = dcvType;
            this.email = email;
        }
    }
}