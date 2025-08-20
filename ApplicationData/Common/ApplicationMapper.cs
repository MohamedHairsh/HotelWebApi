using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using AutoMapper;
namespace ApplicationLayer.Common
{
    public class ApplicationMapper : Profile
    {

        public ApplicationMapper()
        {
            CreateMap<HotelDto, Hotel>()
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.HotelAdminId)).ReverseMap()
               .ForMember(dest => dest.HotelAdminId, opt => opt.MapFrom(src => src.CreatedBy));
            CreateMap<BookingDto, Booking>().ReverseMap();
            CreateMap<HotelRoomDto, HotelRoom>().ReverseMap();
            CreateMap<FacilityDto, Facility>().ReverseMap();
            CreateMap<BookingLogDto, BookingLog>().ReverseMap();
            CreateMap<RoomFacilityDto, RoomFacility>().ReverseMap();
            CreateMap<RoomAvailabilityDto, RoomAvailability>().ReverseMap();
            CreateMap<RoomSeasonalPriceDto, RoomSeasonalPrice>().ReverseMap();
            CreateMap<HotelImageDto, HotelImage>().ReverseMap();
            CreateMap<HotelPolicyDto, HotelPolicy>().ReverseMap();
            CreateMap<HotelNearbyLandmarkDto, HotelNearbyLandmark>().ReverseMap();
            CreateMap<HotelDiscountDto, HotelDiscount>().ReverseMap();
            CreateMap<HotelFacilityDto, HotelFacility>().ReverseMap();
            CreateMap<HotelReviewDto, HotelReview>().ReverseMap();
            CreateMap<HotelReviewCategoryDto, HotelReviewCategory>().ReverseMap();
            CreateMap<HotelRatingsSummaryDto, HotelRatingsSummary>().ReverseMap();
            CreateMap<HotelUserAssignmentDto, HotelUserAssignment>().ReverseMap();
            CreateMap<WishlistDto, Wishlist>().ReverseMap();
            CreateMap<MasterRoomDto, MasterRoom>().ReverseMap();
            CreateMap<MasterBedDto, MasterBed>().ReverseMap();
            CreateMap<AmenitiesDto, Amenities>().ReverseMap();
        }
    }
}
