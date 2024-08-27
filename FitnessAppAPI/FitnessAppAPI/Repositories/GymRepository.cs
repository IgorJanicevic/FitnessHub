using FitnessAppAPI.IRepositories;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Repositories
{
    public class GymRepository : IGymRepository
    {
        private readonly FitnessHubContext _context;

        public GymRepository(FitnessHubContext context)
        {
            _context = context;
        }

        public void AddGym(Gym gym)
        {
            _context.Gyms.Add(gym);
            _context.SaveChanges();
        }

        public void DeleteGym(int id)
        {
            var gym= _context.Gyms.FirstOrDefault(g=>g.Id==id);
            if (gym != null)
            {
                _context.Gyms.Remove(gym);
                _context.SaveChanges();
            }
        }

        public Gym GetGymById(int id)
        {
            return _context.Gyms.FirstOrDefault(gym => gym.Id==id);
        }

        public IEnumerable<Gym> GetGymsByLocation(string location)
        {
           return _context.Gyms.Where(g=>g.Location.Equals(location)).ToList();
        }

        public void UpdateGym(Gym gym)
        {
            var existingGym= _context.Gyms.FirstOrDefault(g=>g.Id == gym.Id);
            if(existingGym == null)
            {
                throw new InvalidOperationException("Gym not found!");
            }
            _context.Entry(existingGym).CurrentValues.SetValues(gym);
            _context.SaveChanges();
        }
    }
}