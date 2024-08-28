using System.Collections.Generic;
using System.Web.Http;
using FitnessAppAPI.Models;
using FitnessAppAPI.IServices;
using System.Net;

namespace FitnessAppAPI.Controllers
{
    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewService.GetAllReviews();
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetReviewById(int id)
        {
            var review = _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostReview([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _reviewService.AddReview(review);
            return Ok(review);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult PutReview(int id, [FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != review.Id)
            {
                return BadRequest();
            }
            _reviewService.UpdateReview(review);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteReview(int id)
        {
            var foundReview= _reviewService.GetReviewById(id);
            if (foundReview == null)
            {
                return NotFound();
            }
            _reviewService.DeleteReview(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
