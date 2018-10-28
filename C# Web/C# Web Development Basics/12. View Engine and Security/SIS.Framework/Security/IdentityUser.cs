namespace SIS.Framework.Security
{
    using SIS.Framework.Security.Base;
    using System;

    public class IdentityUser : IdentityUserT<string>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
