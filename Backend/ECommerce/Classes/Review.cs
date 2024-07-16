namespace ECommerce.Classes
{
    public class Review
    {
        public required string UserId { get; set; }
        public string? Description { get; set; }
        public required int Rating { get; set; }
    }
}
