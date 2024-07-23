using ECommerce.Classes;
using ECommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTO
{
    public class UserDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
