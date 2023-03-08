using BusinessLogic.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DelavoreContext _context;
        public UserRepository(DelavoreContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
          foreach(User user in _context.Users)
            {
                yield return user;
            }
        }

        public User GetUser(Guid id)
        {
           return _context.Users.Find(id);
        }

        public void UpdateUser(User user)
        {
             _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
