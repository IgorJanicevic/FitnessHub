using FitnessAppAPI.IRepositories;
using FitnessAppAPI.IServices;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Services
{
    public class GymService : IGymService
    {
        private readonly IGymRepository _repository;

        public GymService(IGymRepository repository)
        {
            _repository = repository;
        }

        public void AddGym(Gym gym)
        {
            _repository.AddGym(gym);
        }

        public void DeleteGym(int id)
        {
            _repository.DeleteGym(id);
        }

        public Gym GetGymById(int id)
        {
            return _repository.GetGymById(id);
        }

        public IEnumerable<Gym> GetGymsByLocation(string location)
        {
            return _repository.GetGymsByLocation(location);
        }

        public void UpdateGym(Gym gym)
        {
            _repository.UpdateGym(gym);
        }
    }
}