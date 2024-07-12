using ECommerce.Classes;

namespace ECommerce.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Email { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public Cart? Cart { get; set; }
        
        // setting a relationship with purchases table
        public int PurchaseId { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
