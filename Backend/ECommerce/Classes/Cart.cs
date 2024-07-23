namespace ECommerce.Classes
{
    public class Cart
    {
        public int TotalPrice { get; set; }
        public virtual List<PurchaseProduct>? PurchaseProducts { get; set;}
    }
}
