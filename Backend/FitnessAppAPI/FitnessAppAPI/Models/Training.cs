using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Training
    {
        public int Id { get; set; }
        public List<int> Exercises { get; set; }
        public List<int?> Reps { get; set; } = null;
        public List<int?> Weights { get; set; } = null;

        // Navigation Properties
        public ICollection<Exercise> ExerciseDetails { get; set; }

    }
}