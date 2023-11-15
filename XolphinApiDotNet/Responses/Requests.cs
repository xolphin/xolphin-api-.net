using System.Collections.Generic;
using System.Linq;

namespace XolphinApiDotNet.Responses
{
    internal class AllRequests : Base
    {
        public IEnumerable<Request> Requests 
        {
            get
            {
                return GetEmbeddedEnumerable<Request>("requests").ToArray();
            }
        }
    }
}