using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Common;
using ApplicationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.AppDbContexts
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
      
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingLog> BookingLogs { get; set; }
        public DbSet<MasterRoom> MasterRoom { get; set; }
        public DbSet<MasterBed> MasterBed { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelDiscount> HotelDiscounts { get; set; }
        public DbSet<HotelFacility> HotelFacilities { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<HotelNearbyLandmark> HotelNearbyLandmarks { get; set; }
        public DbSet<HotelPolicy> HotelPolicies { get; set; }
        public DbSet<HotelRatingsSummary> HotelRatingsSummaries { get; set; }
        public DbSet<HotelReview> HotelReviews { get; set; }
        public DbSet<HotelReviewCategory> HotelReviewCategories { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelUserAssignment> HotelUserAssignments { get; set; }
        public DbSet<RoomAvailability> RoomAvailabilities { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<RoomSeasonalPrice> RoomSeasonalPrices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Amenities> Amenities { get; set; }

        public DbSet<Staff> Staffs { get; set; }


    }
}
