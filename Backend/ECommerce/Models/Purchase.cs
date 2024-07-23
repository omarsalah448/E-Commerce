using ECommerce.Classes;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public List<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        // setting a relationship with User table
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }   
}
