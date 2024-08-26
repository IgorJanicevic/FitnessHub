using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Veza sa korisnikom
        public int GymId { get; set; } // Veza sa teretanom
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentStatus { get; set; } // "Paid", "Pending"
    }

}