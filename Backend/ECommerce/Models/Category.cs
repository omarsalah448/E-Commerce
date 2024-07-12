namespace ECommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        // setting a relationship with product table
        public int ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
