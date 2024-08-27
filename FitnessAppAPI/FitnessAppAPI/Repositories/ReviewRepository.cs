using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FitnessAppAPI.Models;
using FitnessAppAPI.IRepositories;

namespace FitnessAppAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly FitnessHubContext _context;

        public ReviewRepository(FitnessHubContext context)
        {
            _context = context;
        }

        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            var existingReview = _context.Reviews.FirstOrDefault(r => r.Id == id);
            if (existingReview == null)
            {
                throw new KeyNotFoundException("Review not found.");
            }
            _context.Reviews.Remove(existingReview);
            _context.SaveChanges();
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateReview(Review review)
        {
            var existingReview = _context.Reviews.FirstOrDefault(r => r.Id == review.Id);
            if (existingReview == null)
            {
                throw new KeyNotFoundException("Review not found.");
            }
            _context.Entry(existingReview).CurrentValues.SetValues(review);
            _context.SaveChanges();
        }
    }
}
