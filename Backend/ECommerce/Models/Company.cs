namespace ECommerce.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LogoURL { get; set; }
        public string? Description { get; set; }

        // setting a relationship with product table
        public int ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set;}
    }
}
