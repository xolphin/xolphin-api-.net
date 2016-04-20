namespace XolphinApiDotNet.Requests
{
    public class CancelSettings
    {
        public bool Revoke { get; set; }
        public string Reason { get; private set; }

        public CancelSettings(string reason)
        {
            Reason = reason;
        }

        public CancelSettings SetRevoke(bool revoke)
        {
            Revoke = revoke;
            return this;
        }
    }
}