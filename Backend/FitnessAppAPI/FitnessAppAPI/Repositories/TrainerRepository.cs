using FitnessAppAPI.IRepositories;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly FitnessHubContext _context;

        public TrainerRepository(FitnessHubContext context)
        {
            _context = context;
        }

        public void AddTrainer(Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
        }

        public void DeleteTrainer(int id)
        {
            var existingTrainer= _context.Trainers.FirstOrDefault(x => x.Id == id);
            if (existingTrainer == null)
            {
                throw new InvalidOperationException("Trainer not found.");
            }
            else
            {
                _context.Trainers.Remove(existingTrainer);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Trainer> GetAllTrainers()
        {
            return _context.Trainers.ToList();
        }

        public IEnumerable<Trainer> GetAllTrainersByGymId(int gymId)
        {
            return _context.Trainers.Where(t=>t.GymId == gymId).ToList();

        }

        public Trainer GetTrainerById(int id) => _context.Trainers.FirstOrDefault(t => t.Id == id);
        

        public void UpdateTrainer(Trainer trainer)
        {
            Trainer existingTrainer= _context.Trainers.FirstOrDefault(t=>t.Id == trainer.Id);
            if(existingTrainer == null)
            {
                throw new InvalidOperationException("Trainer not found for update.");
            }
            else
            {
                _context.Entry(existingTrainer).CurrentValues.SetValues(trainer);
                _context.SaveChanges();
            }
        }
    }
}