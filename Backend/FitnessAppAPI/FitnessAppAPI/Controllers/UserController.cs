using FitnessAppAPI.DTO;
using FitnessAppAPI.Helpers;
using FitnessAppAPI.IServices;
using FitnessAppAPI.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FitnessAppAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        // Koristi Dependency Injection da proslijedi UserService
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var allUsers = _userService.GetAllUsers();
                if (allUsers != null)
                    return Ok(allUsers);
                return NotFound();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/users/register
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register([FromBody] UserRegistrationDto userDto)
        {
            try
            {
                var user = _userService.Register(userDto);

                // Generisanje JWT tokena
                var token = JwtTokenGenerator.GenerateToken(user.Id.ToString());

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/users/login
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                var user = _userService.Login(loginDto);

                // Generisanje JWT tokena
                var token = JwtTokenGenerator.GenerateToken(user.Id.ToString());

                return Ok(new { Token = token });
            }
            catch (Exception )
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("profile")]
        public IHttpActionResult GetProfile()
        {
            var token = Request.Headers.Authorization?.Parameter;
            if (token == null)
            {
                return Unauthorized();
            }

            var principal = JwtTokenValidator.ValidateToken(token);
            if (principal == null)
            {
                return Unauthorized();
            }

            var userId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var user = _userService.GetProfile(userId);
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
