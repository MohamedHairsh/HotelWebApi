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

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<HotelImages> HotelImages { get; set; }
        public DbSet<HotelRooms> HotelRooms { get; set; }
        public DbSet<HotelPolicies> HotelPolicies { get; set; }
        public DbSet<HotelFacilities> HotelFacilities { get; set; }
        public DbSet<RoomFacilities> RoomFacilities { get; set; }
        public DbSet<RoomSeasonalPrices> RoomSeasonalPrices { get; set; }
        public DbSet<RoomAvailability> RoomAvailabilities { get; set; }
        public DbSet<HotelNearbyLandmarks> HotelNearbyLandmarks { get; set; }
        public DbSet<HotelDiscounts> HotelDiscounts { get; set; }

        public DbSet<Facilities> Facilities { get; set; }
    }
}
