using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FitnessAppAPI
{
    public class FitnessHubContext : DbContext
    {
        public FitnessHubContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlan { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Training> Training { get; set; }

        // Ako koristiš Fluent API za konfiguraciju:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Konfiguracija entiteta može ići ovde
        }
    }
}