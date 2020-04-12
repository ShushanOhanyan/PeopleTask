using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Models;

namespace People.Data
{
    public interface IUserRepository
    {
        User AddUser(User user);

        IEnumerable<User> GetAllUsers();

        void EditUser(User user);
    }
}
