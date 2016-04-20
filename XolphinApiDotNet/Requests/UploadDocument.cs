namespace XolphinApiDotNet.Requests
{
    public class UploadDocument
    {
        public byte[] Document { get; private set; }
        public string Description { get; set; }

        public UploadDocument(byte[] document)
        {
            Document = document;
        }

        public UploadDocument SetDescription(string description)
        {
            Description = description;
            return this;
        }
    }
}