using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class GymDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal MembershipPrice { get; set; }
        public int OwnerId { get; set; }
    }
}