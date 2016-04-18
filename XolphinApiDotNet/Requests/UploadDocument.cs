namespace XolphinApiDotNet.Requests
{
    public class UploadDocument
    {
        public byte[] document { get; private set; }
        public string description { get; set; }

        public UploadDocument(byte[] document)
        {
            this.document = document;
        }

        public UploadDocument SetDescription(string description)
        {
            this.description = description;
            return this;
        }
    }
}