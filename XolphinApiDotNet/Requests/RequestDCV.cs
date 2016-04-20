using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class RequestDCV
    {
        public string Domain { get; private set; }
        public DCVType DCVType { get; private set; }
        public string ApproverEmail { get; private set; }

        public RequestDCV(string domain, DCVType dcvType, string approverEmail) 
        {
            Domain = domain;
            DCVType = dcvType;
            ApproverEmail = approverEmail;
        }
    }
}