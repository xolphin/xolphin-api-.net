using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XolphinApiDotNet.Example
{
    public class RequestGetNotes
    {
        public RequestGetNotes()
        {
            var client = new XolphinApiDotNet.Client("fake_login@xolphin.api", "Sup3rSecre7P@s$w0rdForThe@p1", testMode:true);

            var result = client.Request.GetNotes(960000000);
            foreach (Responses.Note note in result.Notes)
            {
                Console.WriteLine(note.Message);
            }
        }
    }
}
