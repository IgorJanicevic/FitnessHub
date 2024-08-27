using FitnessAppAPI.IRepositories;
using FitnessAppAPI.IServices;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }


        public void AddTrainer(Trainer trainer)
        {
            if (TrainerExistInGym(trainer))
            {
                throw new InvalidOperationException("Trainer already work in gym.");
            }
            _trainerRepository.AddTrainer(trainer);
        }
        
        public void DeleteTrainer(int id) => _trainerRepository.DeleteTrainer(id);

        public IEnumerable<Trainer> GetAllTrainers() => _trainerRepository.GetAllTrainers();

        public IEnumerable<Trainer> GetAllTrainersByGymId(int gymId) => _trainerRepository.GetAllTrainersByGymId(gymId);

        public Trainer GetTrainerById(int id) => _trainerRepository.GetTrainerById(id);

        public void UpdateTrainer(Trainer trainer)
        {
            if (TrainerUpdatedIds(trainer))
            {
                throw new InvalidOperationException("Trainer cannot change ids.");
            }
            _trainerRepository.UpdateTrainer(trainer);
        }

        private bool TrainerUpdatedIds(Trainer trainer)
        {
            var foundTrainer= _trainerRepository.GetTrainerById(trainer.Id);
            if(foundTrainer.UserId!=trainer.Id || foundTrainer.GymId != trainer.GymId)
            {
                return true;
            }
            return false;
        }

        private bool TrainerExistInGym(Trainer trainer)
        {
            var trainersFound = _trainerRepository.GetAllTrainersByGymId(trainer.GymId);
            if (trainersFound.Any(t => t.UserId == trainer.UserId))
                return true;
            return false;
        }
    }
}