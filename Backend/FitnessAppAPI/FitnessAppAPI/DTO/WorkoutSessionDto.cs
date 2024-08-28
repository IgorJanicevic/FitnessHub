using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class WorkoutSessionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }
        public int GymId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // "Individual" ili "Group"
        public string Status { get; set; } // "Scheduled", "Cancelled"
    }

}