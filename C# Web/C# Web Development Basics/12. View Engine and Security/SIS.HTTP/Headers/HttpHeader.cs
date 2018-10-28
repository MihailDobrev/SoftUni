namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
        public const string ContentType = "Content-Type";

        public const string ContentLength = "Content-Length";

        public const string ContentDisposition = "Content-Disposition"; 

        public HttpHeader(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString() => $"{this.Key}: {this.Value}";

         
    }
}
