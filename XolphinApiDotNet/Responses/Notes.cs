using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class AllNotes : Base
    {
        public IEnumerable<Note> Notes 
        {
            get
            {
                return GetEmbeddedEnumerable<Note>("notes");
            }
        }
    }
}