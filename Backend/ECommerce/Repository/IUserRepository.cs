using ECommerce.DTO;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Repository
{
    public interface IUserRepository
    {
        public List<User> Get();
        public User? GetById(int id);
        public int Post(UserDTO userDTO);
        public int Put(int id, UserDTO userDTO);
        public int Delete(int id);
        public bool IsEmailUnique(string email);
        public bool IsPhoneNumberUnique(string phoneNumber);
    }
}
