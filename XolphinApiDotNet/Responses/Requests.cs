using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Requests : Base
    {
        public IEnumerable<Request> requests 
        {
            get
            {
                return GetEmbeddedEnumerable<Request>("requests");
            }
        }
    }
}