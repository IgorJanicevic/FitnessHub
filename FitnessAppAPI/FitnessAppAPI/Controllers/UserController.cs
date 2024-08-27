using FitnessAppAPI.DTO;
using FitnessAppAPI.Helpers;
using FitnessAppAPI.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace FitnessAppAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private FitnessHubContext _context = new FitnessHubContext();

        // POST api/users/register
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody] UserRegistrationDto userDto)
        {
            try
            {
                if (_context.Users.Any(u => u.Email == userDto.Email))
                {
                    return BadRequest("Email already exists.");
                }

                User user = new User
                {
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Role = userDto.Role,
                    RegistrationDate = DateTime.UtcNow
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                // Generisanje JWT tokena ovde
                var token = JwtTokenGenerator.GenerateToken(user.Id.ToString());

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                // Logovanje greške
                return InternalServerError(ex);
            }
        }

        // POST api/users/login
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserLoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            // Generisanje JWT tokena ovde
            var token = JwtTokenGenerator.GenerateToken(user.Id.ToString());

            return Ok(new { Token = token });
        }

        [HttpGet]
        [Route("profile")]
        public IHttpActionResult GetProfile()
        {
            // Dohvati token iz Authorization headera
            var token = Request.Headers.Authorization?.Parameter;
            if (token == null)
            {
                return Unauthorized();
            }

            // Validiraj token i dohvati ClaimsPrincipal
            var principal = JwtTokenValidator.ValidateToken(token);
            if (principal == null)
            {
                return Unauthorized();
            }

            // Izvuci userId iz tokena
            var userIdString = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (userIdString == null || !int.TryParse(userIdString, out int userId))
            {
                return Unauthorized();
            }

            // Loguj userId za debagovanje
            System.Diagnostics.Debug.WriteLine($"User ID from token: {userId}");

            // Pretpostavlja se da koristiš neki način za dobijanje korisničkih podataka iz baze
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

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
