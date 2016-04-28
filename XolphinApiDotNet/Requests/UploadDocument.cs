namespace XolphinApiDotNet.Requests
{
    public class UploadDocument
    {
        public string Name { get; private set; }
        public byte[] Document { get; private set; }
        public string Description { get; set; }

        public UploadDocument(string name, byte[] document)
        {
            Name = name;
            Document = document;
        }

        public UploadDocument SetDescription(string description)
        {
            Description = description;
            return this;
        }
    }
}