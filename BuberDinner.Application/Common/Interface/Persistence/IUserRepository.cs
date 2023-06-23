using BuberDinner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Interface.Persistence
{
    public interface IUserRepository
    {
        User? GetUserById(string email);
        void Add(User user);
    }
}
