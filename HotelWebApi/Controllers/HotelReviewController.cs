using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelReviewController : ControllerBase
    {
        private readonly IHotelReviewRepository _repository;

        public HotelReviewController(IHotelReviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllHotelReview")]
        public async Task<IActionResult> GetAllHotelReview()
        {
            var reviews = await _repository.GetAllHotelReview();
            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById(Guid reviewId)
        {
            var review = await _repository.GetReviewByIdAsync(reviewId);
            if (review == null) return NotFound("Review not found");

            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] HotelReviewDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _repository.AddReviewAsync(dto);
            return CreatedAtAction(nameof(GetReviewById), new { reviewId = result.HotelId }, result);
        }

        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateReview(Guid reviewId, [FromBody] HotelReviewDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _repository.UpdateHotelReviewAsync(reviewId, dto);
            if (updated == null) return NotFound("Review not found");

            return Ok(updated);
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(Guid reviewId)
        {
            var deleted = await _repository.DeleteReviewAsync(reviewId);
            if (!deleted) return NotFound("Review not found");

            return Ok(new { Message = "Review deleted successfully" });
        }

        [HttpGet("hotel/{hotelId}/average-rating")]
        public async Task<IActionResult> GetAverageRating(Guid hotelId)
        {
            var avgRating = await _repository.GetAverageRatingByHotelIdAsync(hotelId);
            return Ok(new { HotelId = hotelId, AverageRating = avgRating });
        }

    }
}
