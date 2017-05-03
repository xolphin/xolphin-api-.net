using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XolphinApiDotNet.Example
{
    public class RequestSendNote
    {
        public RequestSendNote()
        {
            var client = new XolphinApiDotNet.Client("fake_login@xolphin.api", "Sup3rSecre7P@s$w0rdForThe@p1");
            client.TestMode(true);
            var note = new XolphinApiDotNet.Requests.NoteSend("test note from .NET #100");
            var result = client.Request.SendNote(960000000, note);
            Console.WriteLine(result.Message);
        }
    }
}
