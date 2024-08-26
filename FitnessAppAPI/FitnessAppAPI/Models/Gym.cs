using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; } // Veza sa vlasnikom teretane
        public decimal MembershipPrice { get; set; }
    }
}