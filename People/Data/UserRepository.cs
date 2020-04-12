using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using People.Models;

namespace People.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly PeopleDBContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(PeopleDBContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public User AddUser(User user)
        {
            User newUser = null;
            try
            {
                newUser = _context.Users.Add(user.ToDALModel()).Entity.ToModel();
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return newUser;
        }

        public void EditUser(User user)
        {
            try
            {
                var oldUser = _context.Users.FirstOrDefault(e => e.Id == user.Id);

                if (oldUser != null)
                {
                    oldUser.Email = user.Email;
                    oldUser.Name = user.Name;
                    oldUser.PhoneNumber = user.PhoneNumber;
                    oldUser.Relation = user.Relation;
                    oldUser.Surname = user.Surname;
                }

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
           
        }

        public void RemoveUser(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(e => e.Id == id);

                if (user != null)
                {
                    _context.Users.Remove(user);
                }

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
           
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                foreach (var item in _context.Users)
                {
                    users.Add(item.ToModel());
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return users;
        }
    }
}
