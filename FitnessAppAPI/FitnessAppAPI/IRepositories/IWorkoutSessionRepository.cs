using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppAPI.IRepositories
{
    public interface IWorkoutSessionRepository
    {
        IEnumerable<WorkoutSession> GetAllWorkoutSessions();
        WorkoutSession GetWorkoutSessionById(int id);
        IEnumerable<WorkoutSession> GetWorkoutSessionsByGymId(int gymId);
        IEnumerable<WorkoutSession> GetWorkoutSessionsByUserId(int userId);
        void AddWorkoutSession(WorkoutSession workoutSession);
        void UpdateWorkoutSession(WorkoutSession workoutSession);
        void DeleteWorkoutSession(int id);
    }
}
