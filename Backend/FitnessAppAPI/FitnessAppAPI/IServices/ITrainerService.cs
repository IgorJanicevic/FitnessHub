using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppAPI.IServices
{
    public interface ITrainerService
    {
        IEnumerable<Trainer> GetAllTrainers();
        IEnumerable<Trainer> GetAllTrainersByGymId(int gymId);
        Trainer GetTrainerById(int id);
        void AddTrainer(Trainer trainer);
        void UpdateTrainer(Trainer trainer);
        void DeleteTrainer(int id);

    }
}
