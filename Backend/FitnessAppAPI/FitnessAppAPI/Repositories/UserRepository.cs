using FitnessAppAPI.IRepositories;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FitnessHubContext _context;

        public UserRepository(FitnessHubContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Id == id);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u=> u.Id == id);
        }

        public void UpdateUser(User user)
        {
            var existingUser= _context.Users.FirstOrDefault(u=>u.Id==user.Id);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User not found!");
            }
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
        }
    }
}