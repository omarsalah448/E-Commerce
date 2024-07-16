namespace ECommerce.Classes
{
    public class Cart
    {
        public int TotalPrice { get; set; } = 0;
        public virtual List<PurchaseProduct>? PurchaseProducts { get; set;}
    }
}
