namespace SIS.Framework.Attributes.Methods
{
    using SIS.Framework.Attributes.Methods.Base;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extensions;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.Capitalize() == nameof(HttpRequestMethod.Post))
            {
                return true;
            }

            return false;
        }
    }
}
