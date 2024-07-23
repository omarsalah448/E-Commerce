namespace ECommerce.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LogoURL { get; set; }
        public string? Description { get; set; }

        // setting a relationship with product table
        public virtual List<Product> Products { get; set;}
    }
}
