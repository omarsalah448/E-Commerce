using ECommerce.Classes;

namespace ECommerce.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; }
        public int Rating { get; set; }
        public IEnumerable<Review> Reviews { get; set; }

        // setting a relationship with company table
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // setting a relationship with category table
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
