using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Certificates : Base
    {
        public IEnumerable<Certificate> certificates
        {
            get
            {
                return GetEmbeddedEnumerable<Certificate>("certificates");
            }
        }
    }
}