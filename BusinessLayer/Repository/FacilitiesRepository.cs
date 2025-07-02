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
    public class FacilitiesRepository : IFacilitiesRepository
    {





        private readonly HotelDbContext _db;// injecting the DI
        public FacilitiesRepository(HotelDbContext db)
        {
            _db = db;
        }
        public async Task<string> CreateHotelFacilities(Facilities facilities)
        {
            facilities.FacilityId = Guid.NewGuid();
            //  hotels.CreatedDate = DateTime.UtcNow;
            _db.Facilities.Add(facilities);
            await _db.SaveChangesAsync();
            return "HotelFacilities Is Created Successfully";
        }

       

        public async Task DeleteHotelFacilities(Guid id)
        {
            var hotelFacilities = await _db.Facilities.FindAsync(id);
            if (hotelFacilities != null)
            {
                _db.Facilities.Remove(hotelFacilities);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("HotelFacilities not found");
            }
        }

        public async Task<List<Facilities>> GetAllById(Guid id)
        {
            return await _db.Facilities
                            .Where(h => h.FacilityId == id)
                            .ToListAsync();
        }


        public async Task<List<Facilities>> GetAllFacilities()
        {
            return await _db.Facilities.ToListAsync();
        }






        public async Task<Facilities> UpdateHotelFacilities(Facilities facilities)
        {
            var existingHotelFAcilitiest = await _db.Facilities.FindAsync(facilities.FacilityId);
            if (existingHotelFAcilitiest == null)
            {
                throw new Exception("HoteFAcilities not found");
            }

            _db.Entry(existingHotelFAcilitiest).CurrentValues.SetValues(facilities);
            await _db.SaveChangesAsync();

            return facilities;
        }
    }
}
