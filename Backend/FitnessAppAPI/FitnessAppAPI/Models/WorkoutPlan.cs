using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> Trainings { get; set; }


        // Navigation Properties
        public User User { get; set; }
        public ICollection<Training> TrainingDetails { get; set; }
    }

}