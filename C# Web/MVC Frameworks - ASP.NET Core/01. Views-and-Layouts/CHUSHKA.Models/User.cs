using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CHUSHKA.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
