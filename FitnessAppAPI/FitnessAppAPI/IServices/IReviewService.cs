using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppAPI.IServices
{
    public interface IReviewService
    {
        void AddReview(Review review);
        void DeleteReview(int id);
        IEnumerable<Review> GetAllReviews();
        Review GetReviewById(int id);
        void UpdateReview(Review review);
    }
}
