using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.DTO
{
    public class UserDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? CountryCode { get; set; }
        public string? MobileNumber { get; set; }
        public required string Password { get; set; }
    }
}
