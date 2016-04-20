using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    internal class AllRequests : Base
    {
        public IEnumerable<Request> Requests 
        {
            get
            {
                return GetEmbeddedEnumerable<Request>("requests");
            }
        }
    }
}