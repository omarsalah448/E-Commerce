using ECommerce.Database;
using ECommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
