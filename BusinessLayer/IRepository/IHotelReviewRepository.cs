using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IHotelReviewRepository
    {
        Task<HotelReviewDto?> GetReviewByIdAsync(Guid reviewId);
        //Task<HotelReviewDto> AddReviewAsync(HotelReviewDto reviewDto);

        Task<HotelReviewDto> AddReviewAsync(HotelReviewDto reviewDto);
        Task<bool> DeleteReviewAsync(Guid reviewId);
        Task<double> GetAverageRatingByHotelIdAsync(Guid hotelId);
        Task<List<HotelReviewDto>> GetAllHotelReview();
        Task<HotelReviewDto?> UpdateHotelReviewAsync(Guid reviewId, HotelReviewDto reviewDto);

    }
}
