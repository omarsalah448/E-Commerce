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
            catch (Exception)
            {
                return new List<User>();
            }
        }

        public User? GetById(int id)
        {
                return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool IsEmailUnique(string email)
        {
            if (email is null)
            {
                return true;
            }
            User? user = context.Users.FirstOrDefault(u => u.Email == email);
            if (user is null)
            {
                return true;
            }
            return false;
        }

        public bool IsPhoneNumberUnique(string phoneNumber)
        {
            if (phoneNumber is null)
            {
                return true;
            }
            User? user = context.Users.FirstOrDefault(u => u.PhoneNumber.Number == phoneNumber);
            if (user is null)
            {
                return true;
            }
            return false;
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

        public int Put(int id, UserDTO userDTO)
        {
            User? user = GetById(id);
            if (user == null)
            {
                return StatusCodes.Status404NotFound;
            }
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            if (userDTO.CountryCode is not null && userDTO.MobileNumber is not null){
                user.PhoneNumber = new PhoneNumber
                {
                    CountryCode = userDTO.CountryCode,
                    Number = userDTO.MobileNumber
                };
            }
            context.SaveChanges();
            return StatusCodes.Status200OK;
        }

        public int Delete(int id)
        {
            User? user = GetById(id);
            if (user == null)
            {
                return StatusCodes.Status404NotFound;
            }
            context.Users.Remove(user);
            context.SaveChanges();
            return StatusCodes.Status200OK;
        }
    }
}
