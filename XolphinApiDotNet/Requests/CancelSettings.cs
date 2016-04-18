namespace XolphinApiDotNet.Requests
{
    public class CancelSettings
    {
        public bool revoke { get; set; }

        public string reason { get; private set; }

        public CancelSettings(string reason)
        {
            this.reason = reason;
        }

        public CancelSettings SetRevoke(bool revoke)
        {
            this.revoke = revoke;
            return this;
        }
    }
}