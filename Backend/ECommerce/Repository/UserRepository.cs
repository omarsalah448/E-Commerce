using ECommerce.Classes;
using ECommerce.Database;
using ECommerce.DTO;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Entity context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtService jwtService;
        public UserRepository(
            Entity context, 
            UserManager<ApplicationUser> userManager,
            JwtService jwtService
            ) {
            this.context = context;
            this.userManager = userManager;
            this.jwtService = jwtService;
        }
        public async Task<List<ApplicationUser>?> GetAsync()
        {
            try
            {
                return await context.Users.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetByIdAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            if (email is null)
            {
                return true;
            }
            ApplicationUser? user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user is null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber)
        {
            if (phoneNumber is null)
            {
                return true;
            }
            ApplicationUser? user = await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user is null)
            {
                return true;
            }
            return false;
        }

        public async Task<int> AddUserAsync(UserDTO userDTO)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                UserName = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
            };
            try
            {
                IdentityResult result = await userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                    return StatusCodes.Status201Created;
                else
                    return StatusCodes.Status400BadRequest;
            }
            catch
            {
                return StatusCodes.Status500InternalServerError;
            }
        }

        public async Task<string>? LoginAsync(LoginUserDTO loginUserDTO)
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(loginUserDTO.Email);
            if (user is null)
                return null;
            bool success = await userManager.CheckPasswordAsync(user, loginUserDTO.Password);
            if (success)
            {
                var token = await jwtService.createAsync(user);
                return token;
            }
            return null;

        }

        //public int Put(int id, UserDTO userDTO)
        //{
        //    ApplicationUser? user = GetByIdAsync(id);
        //    if (user == null)
        //    {
        //        return StatusCodes.Status404NotFound;
        //    }
        //    user.FirstName = userDTO.FirstName;
        //    user.LastName = userDTO.LastName;
        //    user.Email = userDTO.Email;
        //    context.SaveChanges();
        //    return StatusCodes.Status200OK;
        //}

        //public int Delete(int id)
        //{
        //    ApplicationUser? user = GetByIdAsync(id);
        //    if (user == null)
        //    {
        //        return StatusCodes.Status404NotFound;
        //    }
        //    context.Users.Remove(user);
        //    context.SaveChanges();
        //    return StatusCodes.Status200OK;
        //}
    }
}
