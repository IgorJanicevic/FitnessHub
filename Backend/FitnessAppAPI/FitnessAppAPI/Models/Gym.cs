using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public decimal MembershipPrice { get; set; }
        public int Members { get; set; } = 0;
        public int ActiveMembers { get; set; } = 0;
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public string ImagePath { get; set; } = "https://media.istockphoto.com/id/1499989647/vector/barbell-fitness.jpg?s=612x612&w=0&k=20&c=VUF3pA7Fd71agKLjzWJN76cnOs0kNHk6ZGi1wONKM9U=";

        
        
    }

}