using ECommerce.Models;
using ECommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<User> users = this.userRepository.Get();
            if (users == null || users.Count == 0)
            {
                return NotFound("No Users Found");
            }
            return Ok(users);
        }

    }
}
