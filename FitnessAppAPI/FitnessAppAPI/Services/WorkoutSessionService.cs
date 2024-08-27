using System.Collections.Generic;
using FitnessAppAPI.IServices;
using FitnessAppAPI.IRepositories;
using FitnessAppAPI.Models;

namespace FitnessAppAPI.Services
{
    public class WorkoutSessionService : IWorkoutSessionService
    {
        private readonly IWorkoutSessionRepository _repository;

        public WorkoutSessionService(IWorkoutSessionRepository repository)
        {
            _repository = repository;
        }

        public void AddWorkoutSession(WorkoutSession workoutSession)
        {
            _repository.AddWorkoutSession(workoutSession);
        }

        public void DeleteWorkoutSession(int id)
        {
            _repository.DeleteWorkoutSession(id);
        }

        public IEnumerable<WorkoutSession> GetAllWorkoutSessions()
        {
            return _repository.GetAllWorkoutSessions();
        }

        public IEnumerable<WorkoutSession> GetWorkoutSessionsByGymId(int gymId)
        {
            return _repository.GetWorkoutSessionsByGymId(gymId);
        }

        public IEnumerable<WorkoutSession> GetWorkoutSessionsByUserId(int userId)
        {
            return _repository.GetWorkoutSessionsByUserId(userId);
        }

        public WorkoutSession GetWorkoutSessionById(int id)
        {
            return _repository.GetWorkoutSessionById(id);
        }

        public void UpdateWorkoutSession(WorkoutSession workoutSession)
        {
            _repository.UpdateWorkoutSession(workoutSession);
        }
    }
}
