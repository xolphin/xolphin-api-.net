using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class RequestDCV
    {
        public string domain { get; private set; }
        public DCVType dcvType { get; private set; }
        public string approverEmail { get; private set; }

        public RequestDCV(string domain, DCVType dcvType, string approverEmail) 
        {
            this.domain = domain;
            this.dcvType = dcvType;
            this.approverEmail = approverEmail;
        }
    }
}