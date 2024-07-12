namespace ECommerce.Classes
{
    public class Cart
    {
        public int TotalPrice { get; set; }
        public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set;}
    }
}
