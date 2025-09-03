using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using AutoMapper;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class HotelReviewRepository : IHotelReviewRepository
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public HotelReviewRepository(HotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HotelReviewDto>> GetAllHotelReview()
        {
            var reviews = await _context.HotelReviews.ToListAsync();
            return _mapper.Map<List<HotelReviewDto>>(reviews);
        }

        public async Task<HotelReviewDto?> GetReviewByIdAsync(Guid reviewId)
        {
            var review = await _context.HotelReviews
                                       .FirstOrDefaultAsync(r => r.ReviewId == reviewId);
            return _mapper.Map<HotelReviewDto?>(review);
        }

        public async Task<HotelReviewDto> AddReviewAsync(HotelReviewDto reviewDto)
        {
            var review = _mapper.Map<HotelReview>(reviewDto);
           
            review.SubmittedDate = DateTime.UtcNow;
            review.CreatedDate = DateTime.UtcNow;
            review.CreatedBy = reviewDto.UserId;


            _context.HotelReviews.Add(review);
            await _context.SaveChangesAsync();

            return _mapper.Map<HotelReviewDto>(review);
        }

        public async Task<bool> DeleteReviewAsync(Guid reviewId)
        {
            var review = await _context.HotelReviews.FindAsync(reviewId);
            if (review == null) return false;

            _context.HotelReviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<double> GetAverageRatingByHotelIdAsync(Guid hotelId)
        {
            return await _context.HotelReviews
                                 .Where(r => r.HotelId == hotelId)
                                 .AverageAsync(r => (double?)r.Rating) ?? 0.0;
        }

        public async Task<HotelReviewDto?> UpdateHotelReviewAsync(Guid reviewId, HotelReviewDto reviewDto)
        {
            var existingReview = await _context.HotelReviews.FindAsync(reviewId);
            if (existingReview == null) return null;

            // Map updated values
            existingReview.ReviewerName = reviewDto.ReviewerName;
            existingReview.ReviewerCountry = reviewDto.ReviewerCountry;
            existingReview.Rating = reviewDto.Rating;
            existingReview.ReviewTitle = reviewDto.ReviewTitle;
            existingReview.ReviewBody = reviewDto.ReviewBody;
           

            await _context.SaveChangesAsync();
            return _mapper.Map<HotelReviewDto>(existingReview);
        }
    }
}
