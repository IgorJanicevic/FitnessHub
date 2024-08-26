using FitnessAppAPI.DTO;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitnessAppAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        // Dummy storage (zameni sa bazom podataka)
        private static List<User> users = new List<User>();

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody] UserRegistrationDto userDto)
        {
            try
            {
                if (users.Any(u => u.Email == userDto.Email))
                {
                    return BadRequest("Email already exists.");
                }

                User user = new User
                {
                    Id = users.Count + 1,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Role = userDto.Role,
                    RegistrationDate = DateTime.UtcNow
                };

                users.Add(user);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                // Logovanje greške
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserLoginDto loginDto)
        {
            var user = users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            // Generisanje JWT tokena ovde
            var token = "dummy-jwt-token";

            return Ok(new { Token = token });
        }

        [HttpGet]
        //[Authorize]
        [Route("profile")]
        public IHttpActionResult GetProfile()
        {
            var userId = 1; // Ovde parsiraj ID iz JWT tokena
            var user = users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var userProfile = new UserProfileDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                MembershipStatus = user.MembershipStatus,
                RegistrationDate = user.RegistrationDate
            };

            return Ok(userProfile);
        }
    }

}
