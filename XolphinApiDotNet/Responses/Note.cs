using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models.Response;

namespace XolphinApiDotNet.Responses
{
    public class Note : Base
    {
        public string Contact { get; set; }
        public string Staff { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime DateTime { get; set; }
    }
}