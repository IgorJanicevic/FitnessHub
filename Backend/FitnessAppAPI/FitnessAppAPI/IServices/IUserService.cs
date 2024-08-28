using FitnessAppAPI.DTO;
using FitnessAppAPI.Models;

namespace FitnessAppAPI.IServices
{
    public interface IUserService
    {
        User Register(UserRegistrationDto userDto);
        User Login(UserLoginDto loginDto);
        User GetProfile(string userId);
    }

}
