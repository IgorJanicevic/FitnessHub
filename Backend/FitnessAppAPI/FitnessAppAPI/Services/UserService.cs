using FitnessAppAPI.DTO;
using FitnessAppAPI.IRepositories;
using FitnessAppAPI.IServices;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Services
{
    public class UserService : IUserService
    {
        private readonly FitnessHubContext _context;

        public UserService(FitnessHubContext context)
        {
            _context = context;
        }

        public User Register(UserRegistrationDto userDto)
        {
            if (_context.Users.Any(u => u.Email == userDto.Email))
            {
                throw new Exception("Email already exists.");
            }

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = userDto.Role,
                RegistrationDate = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(UserLoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            return user;
        }

        public User GetProfile(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
        }
    }

}