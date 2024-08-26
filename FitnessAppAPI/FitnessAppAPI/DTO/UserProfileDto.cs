using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string MembershipStatus { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }

}