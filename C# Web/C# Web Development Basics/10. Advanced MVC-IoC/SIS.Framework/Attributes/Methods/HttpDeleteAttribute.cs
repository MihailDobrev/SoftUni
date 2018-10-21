namespace SIS.Framework.Attributes.Methods
{
    using SIS.Framework.Attributes.Methods.Base;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extensions;

    public class HttpDeleteAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.Capitalize() == nameof(HttpRequestMethod.Delete))
            {
                return true;
            }

            return false;
        }
    }
}
