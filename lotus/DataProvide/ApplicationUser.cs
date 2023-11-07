using System;
using Microsoft.AspNetCore.Identity;

namespace lotus.DataProvide
{
	public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            CartItems = new HashSet<Cart>();
            Orders = new HashSet<Order>();

        }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public bool IsAdmin { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Mobile { get; set; }

        public virtual ICollection<Cart> CartItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
}

