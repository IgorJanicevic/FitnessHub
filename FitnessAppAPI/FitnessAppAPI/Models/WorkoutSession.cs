using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Veza sa korisnikom
        public int TrainerId { get; set; } // Veza sa trenerom
        public int GymId { get; set; } // Veza sa teretanom
        public DateTime Date { get; set; }
        public string Type { get; set; } // "Individual", "Group"
        public string Status { get; set; } // "Scheduled", "Cancelled"
    }

}