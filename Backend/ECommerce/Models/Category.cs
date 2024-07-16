namespace ECommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        // setting a relationship with product table
        public virtual List<Product> Products { get; set; }
    }
}
