using System.Collections.Generic;
using FitnessAppAPI.Models;
using FitnessAppAPI.IRepositories;
using FitnessAppAPI.IServices;

namespace FitnessAppAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void AddReview(Review review)
        {
            _reviewRepository.AddReview(review);
        }

        public void DeleteReview(int id)
        {
            _reviewRepository.DeleteReview(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public Review GetReviewById(int id)
        {
            return _reviewRepository.GetReviewById(id);
        }

        public void UpdateReview(Review review)
        {
            _reviewRepository.UpdateReview(review);
        }
    }
}
