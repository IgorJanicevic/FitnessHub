using System.Collections.Generic;
using System.Linq;
using FitnessAppAPI.IRepositories;
using FitnessAppAPI.Models;
using System.Data.Entity;
using System;

namespace FitnessAppAPI.Repositories
{
    public class WorkoutSessionRepository : IWorkoutSessionRepository
    {
        private readonly FitnessHubContext _context;

        public WorkoutSessionRepository(FitnessHubContext context)
        {
            _context = context;
        }

        public void AddWorkoutSession(WorkoutSession workoutSession)
        {
            var foundSession= _context.WorkoutSessions.FirstOrDefault(s => s.Id == workoutSession.Id);
            if (foundSession.TrainerId != workoutSession.TrainerId || foundSession.UserId != foundSession.UserId)
            {
                throw new InvalidOperationException("This workout session already exist.");
            }
            _context.WorkoutSessions.Add(workoutSession);
            _context.SaveChanges();
        }

        public void DeleteWorkoutSession(int id)
        {
            var existingSession = _context.WorkoutSessions.FirstOrDefault(x => x.Id == id);
            if (existingSession != null)
            {
                _context.WorkoutSessions.Remove(existingSession);
                _context.SaveChanges();
            }
        }

        public IEnumerable<WorkoutSession> GetAllWorkoutSessions()
        {
            return _context.WorkoutSessions.ToList();
        }

        public IEnumerable<WorkoutSession> GetWorkoutSessionsByGymId(int gymId)
        {
            return _context.WorkoutSessions.Where(ws => ws.GymId == gymId).ToList();
        }

        public IEnumerable<WorkoutSession> GetWorkoutSessionsByUserId(int userId)
        {
            return _context.WorkoutSessions.Where(ws => ws.UserId == userId).ToList();
        }

        public WorkoutSession GetWorkoutSessionById(int id)
        {
            return _context.WorkoutSessions.FirstOrDefault(ws => ws.Id == id);
        }

        public void UpdateWorkoutSession(WorkoutSession workoutSession)
        {
            var existingSession = _context.WorkoutSessions.FirstOrDefault(ws => ws.Id == workoutSession.Id);
            if (existingSession != null)
            {
                if (existingSession.TrainerId != workoutSession.TrainerId || existingSession.UserId != workoutSession.UserId)
                    throw new InvalidOperationException("Cannot change trainer nor user.");
                _context.Entry(existingSession).CurrentValues.SetValues(workoutSession);
                _context.SaveChanges();
            }
        }
    }
}
