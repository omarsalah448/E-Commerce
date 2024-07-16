using ECommerce.Classes;
using ECommerce.Database;
using ECommerce.DTO;
using ECommerce.Models;
using ECommerce.Repository;
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
        public IActionResult Get()
        {
            List<User> users = this.userRepository.Get();
            if (users == null || users.Count == 0)
            {
                return NotFound("No Users Found");
            }
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                int statusCode = userRepository.Post(userDTO);
                return StatusCode(statusCode);
            }
            return BadRequest(ModelState);
        }
    }
}
