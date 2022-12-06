using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XolphinApiDotNet.Example
{
    public class RequestSendComodoSA
    {
        public RequestSendComodoSA()
        {
            var client = new XolphinApiDotNet.Client("fake_login@xolphin.api", "Sup3rSecre7P@s$w0rdForThe@p1", testMode: true);
            var comodoSA = new XolphinApiDotNet.Requests.ComodoSA("mail@example.com");
            var result = client.Request.SubscribeComodoSA(960000000, comodoSA);
            Console.WriteLine(result.Message);
        }
    }
}
