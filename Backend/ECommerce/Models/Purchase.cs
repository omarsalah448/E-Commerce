using ECommerce.Classes;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public List<PurchaseProduct> PurchaseProducts { get; set; }
        public int TotalPrice { get; set; }
        public DateTime? Date { get; set; }

        // setting a relationship with User table
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }   
}
