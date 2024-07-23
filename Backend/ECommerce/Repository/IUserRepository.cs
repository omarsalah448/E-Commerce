using ECommerce.DTO;
using ECommerce.Models;

namespace ECommerce.Repository
{
    public interface IUserRepository
    {
        public Task<List<ApplicationUser>?> GetAsync();
        public Task<ApplicationUser?> GetByIdAsync(int id);
        public Task<bool> IsEmailUniqueAsync(string email);
        public Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);
        public Task<int> AddUserAsync(UserDTO userDTO);
        //public int Put(int id, UserDTO userDTO);
        //public int Delete(int id);
    }
}