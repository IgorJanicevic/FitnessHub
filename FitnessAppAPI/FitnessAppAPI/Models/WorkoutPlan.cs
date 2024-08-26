using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Veza sa korisnikom
        public string Exercises { get; set; } // Lista vežbi u JSON formatu, npr. [{"name": "Squat", "reps": 10}]
        public string Goal { get; set; } // Npr. "Weight Loss", "Muscle Gain"
    }

}