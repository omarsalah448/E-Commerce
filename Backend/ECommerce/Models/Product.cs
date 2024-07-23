using ECommerce.Classes;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? ImageURL { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();

        // setting a relationship with company table
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // setting a relationship with category table
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
