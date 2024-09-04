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
        private readonly IUserRepository _userRepository;
        

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        //Pri registraciji role je klijent
        public User Register(User userDto)
        {
                var users= _userRepository.GetAllUsers();
                if (users.Any(u => u.Email == userDto.Email))
                {
                    throw new Exception("Email already exists.");
                }
            


            _userRepository.AddUser(userDto);
            return userDto;
        }

        public User Login(UserLoginDto loginDto)
        {
            var user = _userRepository.GetAllUsers().Where(u=>u.Email.Equals(loginDto.Email) && u.Password.Equals(loginDto.Password)).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            return user;
        }

        public User GetProfile(string userId)
        {
            int id= Int32.Parse(userId);
            return _userRepository.GetUserById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }

}