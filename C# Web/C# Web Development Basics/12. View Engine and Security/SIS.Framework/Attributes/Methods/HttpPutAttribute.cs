namespace SIS.Framework.Attributes.Methods
{
    using SIS.Framework.Attributes.Methods.Base;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extensions;

    public class HttpPutAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.Capitalize() == nameof(HttpRequestMethod.Put))
            {
                return true;
            }

            return false;
        }
    }
}
