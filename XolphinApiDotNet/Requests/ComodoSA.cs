namespace XolphinApiDotNet.Requests
{
    public class ComodoSA
    {
        public string Sa_email { get; set; }
        public string Language { get; set; }

        public ComodoSA(string to)
        {
            Sa_email = to;
        }

        public ComodoSA SetLanguage(string language)
        {
            Language = language;
            return this;
        }
    }
}