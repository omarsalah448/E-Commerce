namespace ECommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        // setting a relationship with product table
        public virtual List<Product> Products { get; set; }
    }
}
