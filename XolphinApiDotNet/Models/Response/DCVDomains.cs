namespace XolphinApiDotNet.Models.Response
{
    public class DCVDomains
    {
        public string domain { get; set; }
        public bool status { get; set; }
        public int statusDetail { get; set; }
        public string statusMessage { get; set; }
        public DCVType dcvType { get; set; }
        public string dcvEmail { get; set; }
    }
}