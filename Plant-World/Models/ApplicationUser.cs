﻿using Microsoft.AspNetCore.Identity;

namespace Plant_World.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
    }

    
}
