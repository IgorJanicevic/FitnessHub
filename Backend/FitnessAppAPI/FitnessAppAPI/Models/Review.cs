using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Veza sa korisnikom
        public int? GymId { get; set; } // Veza sa teretanom (može biti null ako je recenzija za trenera)
        public int? TrainerId { get; set; } // Veza sa trenerom (može biti null ako je recenzija za teretanu)
        public int Rating { get; set; } // Ocena od 1 do 5
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }

}