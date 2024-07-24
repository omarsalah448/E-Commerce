using ECommerce.Classes;
using ECommerce.Database;
using ECommerce.DTO;
using ECommerce.Models;
using ECommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerce.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Entity context;
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository, Entity context)
        {
            this.context = context;
            this.userRepository = userRepository;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            List<ApplicationUser>? users = await this.userRepository.GetAsync();
            if (users == null || users.Count == 0)
            {
                return NotFound("No Users Found");
            }
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                bool isEmailUnique = await userRepository.IsEmailUniqueAsync(userDTO.Email);
                if (!isEmailUnique)
                {
                    return BadRequest("This Email is already registered");
                }
                bool isPhoneNumberUnique = await userRepository.IsPhoneNumberUniqueAsync(userDTO.PhoneNumber);
                if (!isPhoneNumberUnique)
                {
                    return BadRequest("This Phone Number is already registered");
                }
                int statusCode = await userRepository.AddUserAsync(userDTO);
                return StatusCode(statusCode);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            if (ModelState.IsValid) { 
            string? token = await userRepository.LoginAsync(loginUserDTO);
                if (!string.IsNullOrEmpty(token))
                    return Ok(token);
            }
            return Unauthorized("Invalid User Credentials");
        }

        //[HttpPut]
        //public IActionResult Put(int id, UserDTO userDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int statusCode = userRepository.Put(id, userDTO);
        //        return StatusCode(statusCode);
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    int statusCode = userRepository.Delete(id);
        //    return StatusCode(statusCode);
        //}
    }
}
