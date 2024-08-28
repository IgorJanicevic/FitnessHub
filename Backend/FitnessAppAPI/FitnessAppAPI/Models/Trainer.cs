using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Veza sa korisnikom
        public int GymId { get; set; } // Veza sa teretanom
        public string Availability { get; set; } // Slobodni termini, npr. "Mon-Fri, 9AM-5PM"
        public double Rating { get; set; }
    }

  
}