using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? TrainerId { get; set; }
        public int? GymId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Trainer Trainer { get; set; }
        public Gym Gym { get; set; }
    }

}