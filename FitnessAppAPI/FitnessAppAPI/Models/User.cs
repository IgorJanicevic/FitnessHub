using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Može biti "Client", "Trainer", "GymOwner", "Admin"
        public string MembershipStatus { get; set; } // "Active", "Expired", "None"
        public DateTime? RegistrationDate { get; set; }
    }
}