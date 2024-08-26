using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class TrainerDetailDto
    {
        public int Id { get; set; }
        public int GymId { get; set; }
        public string Username { get; set; }
        public string Availability { get; set; }
        public double Rating { get; set; }
        public string Email { get; set; }
    }
}