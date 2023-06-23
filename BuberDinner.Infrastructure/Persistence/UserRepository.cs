using BuberDinner.Application.Common.Interface.Persistence;
using BuberDinner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserById(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
