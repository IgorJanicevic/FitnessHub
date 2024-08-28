using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class WorkoutPlanDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Exercises { get; set; } // Lista vežbi u JSON formatu
        public string Goal { get; set; }
    }
}