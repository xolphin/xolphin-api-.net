using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class DCV
    {
        public string Domain { get; private set; }
        public DCVType DCVType { get; private set; }
        public string Email { get; private set; }

        public DCV(string domain, DCVType dcvType, string email)
        {
            Domain = domain;
            DCVType = dcvType;
            Email = email;
        }
    }
}