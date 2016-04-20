namespace XolphinApiDotNet.Models.Response
{
    public class DCVDomains
    {
        public string Domain { get; set; }
        public bool Status { get; set; }
        public int StatusDetail { get; set; }
        public string StatusMessage { get; set; }
        public DCVType DCVType { get; set; }
        public string DCVEmail { get; set; }
    }
}