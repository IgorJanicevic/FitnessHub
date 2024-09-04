using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Gym Gym { get; set; }
    }

}