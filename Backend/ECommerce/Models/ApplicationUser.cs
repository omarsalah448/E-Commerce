using ECommerce.Classes;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Cart Cart { get; set; } = new Cart();

        // setting a relationship with purchases table
        public virtual List<Purchase> Purchases { get; set; }
    }
}