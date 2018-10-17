namespace SIS.Framework.Attributes.Methods.Base
{
    using System;

    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
