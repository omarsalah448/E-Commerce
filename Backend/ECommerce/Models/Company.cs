namespace ECommerce.Models
{
    public class Company
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? LogoURL { get; set; }
        public string? Description { get; set; }

        // setting a relationship with product table
        public virtual List<Product> Products { get; set;}
    }
}
