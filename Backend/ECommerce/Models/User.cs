using ECommerce.Classes;

namespace ECommerce.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
        public required string Password { get; set; }
        public Cart? Cart { get; set; }

        // setting a relationship with purchases table
        public virtual List<Purchase> Purchases { get; set; }
    }
}