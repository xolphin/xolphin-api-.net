using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    internal class AllProducts : Base
    {
        public IEnumerable<Product> Products
        {
            get
            {
                return GetEmbeddedEnumerable<Product>("products");
            }
        }
    }
}