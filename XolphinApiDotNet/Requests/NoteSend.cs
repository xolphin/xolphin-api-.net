namespace XolphinApiDotNet.Requests
{
    public class NoteSend
    {
        public string Message { get; set; }

        public NoteSend(string message)
        {
            Message = message;
        }
    }
}