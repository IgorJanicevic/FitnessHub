using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? GymId { get; set; }
        public int? TrainerId { get; set; }
        public int Rating { get; set; } // Ocena od 1 do 5
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}