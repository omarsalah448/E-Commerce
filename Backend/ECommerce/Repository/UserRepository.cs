using ECommerce.Classes;
using ECommerce.Database;
using ECommerce.DTO;
using ECommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECommerce.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Entity context;
        public UserRepository(Entity context) {
            this.context = context;
        }
        public List<User> Get()
        {
            try
            {
                return context.Users.ToList();
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        public int Post(UserDTO userDTO)
        {
            User user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = userDTO.Password
            };
            if (userDTO.CountryCode is not null && userDTO.MobileNumber is not null)
            {
                user.PhoneNumber = new PhoneNumber
                {
                    CountryCode = userDTO.CountryCode,
                    Number = userDTO.MobileNumber
                };
            }
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return StatusCodes.Status201Created;
            }
            catch
            {
                return StatusCodes.Status500InternalServerError;
            }
        }
    }
}
