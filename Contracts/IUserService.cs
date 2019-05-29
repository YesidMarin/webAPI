using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
