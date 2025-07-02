
using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class HotelFacilitiesRepository : IHotelFacilitiesRepository
    {
        private readonly HotelDbContext _db;
        public HotelFacilitiesRepository(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<string> CreateHotelFacilities(HotelFacilities hotelfacilities)
        {
            hotelfacilities.HotelFacilityId = Guid.NewGuid();
            _db.HotelFacilities.Add(hotelfacilities);
            await _db.SaveChangesAsync();
            return "HotelFacilities Created Successfully";
        }

        public async Task DeleteHotelFacilities(Guid id)
        {
            var hotelfacilities = await _db.HotelFacilities.FindAsync(id);
            if (hotelfacilities != null)
            {
                _db.HotelFacilities.Remove(hotelfacilities);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("HotelFacilities not found");
            }
        }

        public async Task<List<HotelFacilities>> GetAllById(Guid id)
        {
            return await _db.HotelFacilities
                          .Where(h => h.HotelFacilityId == id)
                          .ToListAsync();
        }

        public async Task<List<HotelFacilities>> GetAllHotelFacilities()
        {
            return await _db.HotelFacilities.ToListAsync();
        }

        public async Task<HotelFacilities> UpdateHotelFacilities(HotelFacilities hotelfacilities)
        {
            var existingHotel = await _db.HotelFacilities.FindAsync(hotelfacilities.HotelFacilityId);
            if (existingHotel == null)
            {
                throw new Exception("Hotel not found");
            }

            _db.Entry(existingHotel).CurrentValues.SetValues(hotelfacilities);
            await _db.SaveChangesAsync();

            return hotelfacilities;
        }
    }
}
