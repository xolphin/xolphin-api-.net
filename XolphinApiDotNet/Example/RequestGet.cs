using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XolphinApiDotNet.Example
{
    public class RequestGet
    {
        public RequestGet()
        {
            var client = new XolphinApiDotNet.Client("fake_login@xolphin.api", "Sup3rSecre7P@s$w0rdForThe@p1");
            client.TestMode(true);
            var result = client.Request.Get(960000000);
            Console.WriteLine(result);
            Console.WriteLine(result.Validations);
            Console.WriteLine(result.DomainName);
            Console.WriteLine(result.Message);
            Console.WriteLine(result.ActionRequired);
            Console.WriteLine(result.BrandValidation);
        }
    }
}
