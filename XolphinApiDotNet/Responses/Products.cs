using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Products : Base
    {
        public IEnumerable<Product> products
        {
            get
            {
                return GetEmbeddedEnumerable<Product>("products");
            }
        }
    }
}