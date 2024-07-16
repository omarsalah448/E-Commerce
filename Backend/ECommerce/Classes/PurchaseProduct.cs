namespace ECommerce.Classes
{
    public class PurchaseProduct
    {
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }
        public required int TotalPrice { get; set; }
    }
}
