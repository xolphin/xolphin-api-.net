using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    internal class AllCertificates : Base
    {
        public IEnumerable<Certificate> Certificates
        {
            get
            {
                return GetEmbeddedEnumerable<Certificate>("certificates");
            }
        }
    }
}