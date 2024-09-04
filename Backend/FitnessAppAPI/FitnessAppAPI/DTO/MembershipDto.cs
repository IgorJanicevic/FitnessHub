using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class MembershipDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}