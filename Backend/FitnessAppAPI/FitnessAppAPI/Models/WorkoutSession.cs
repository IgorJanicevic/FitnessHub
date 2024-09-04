using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }
        public int GymId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Status { get; set; } = "Scheduled";

        // Navigation Properties
        public User User { get; set; }
        public Trainer Trainer { get; set; }
        public Gym Gym { get; set; }
    }

}