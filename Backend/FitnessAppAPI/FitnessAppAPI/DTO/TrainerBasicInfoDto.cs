using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.DTO
{
    public class TrainerBasicInfoDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Availability { get; set; }
        public double Rating { get; set; }
    }
}