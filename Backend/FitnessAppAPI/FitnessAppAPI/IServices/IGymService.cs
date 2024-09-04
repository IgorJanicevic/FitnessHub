using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppAPI.IServices
{
    public interface IGymService
    {
        Gym GetGymById(int id);
        IEnumerable<Gym> GetGymsByLocation(string location);
        void AddGym(Gym gym);
        void UpdateGym(Gym gym);
        void DeleteGym(int id); 
    }
}
