using FitnessAppAPI.DTO;
using FitnessAppAPI.Models;
using System.Collections.Generic;

namespace FitnessAppAPI.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User Register(User userDto);
        User Login(UserLoginDto loginDto);
        User GetProfile(string userId);
    }

}
