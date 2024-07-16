using ECommerce.DTO;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Repository
{
    public interface IUserRepository
    {
        public List<User> Get();
        public int Post(UserDTO userDTO);
    }
}
