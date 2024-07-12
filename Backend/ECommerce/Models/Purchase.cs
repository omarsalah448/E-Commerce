using ECommerce.Classes;

namespace ECommerce.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public IEnumerable<PurchaseProduct> PurchaseProducts { get; set; }
        public int TotalPrice { get; set; }
        public DateTime? Date { get; set; }

        // setting a relationship with User table
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }   
}
