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
    public class HotelDiscountRepository : IHotelDiscountRepository
    {

        private readonly HotelDbContext _db;// injecting the DI
        public HotelDiscountRepository(HotelDbContext db)
        {
            _db = db;
        }
        public async Task<string> CreateHotelDiscount(HotelDiscounts hotelDiscounts)
        {
            hotelDiscounts.DiscountId = Guid.NewGuid();
          //  hotels.CreatedDate = DateTime.UtcNow;
            _db.HotelDiscounts.Add(hotelDiscounts);
            await _db.SaveChangesAsync();
            return "HotelDiscount Is Created Successfully";
        }

        //public Task<string> CreateHotelDiscount(HotelDiscounts hotelDiscounts)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task DeleteHotelDiscount(Guid id)
        {
            var hotelDiscount = await _db.HotelDiscounts.FindAsync(id);
            if (hotelDiscount != null)
            {
                _db.HotelDiscounts.Remove(hotelDiscount);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("HotelDiscount not found");
            }
        }

        public async Task<List<HotelDiscounts>> GetAllById(Guid id)
        {
            return await _db.HotelDiscounts
                            .Where(h => h.DiscountId == id)
                            .ToListAsync();
        }

        public async Task<List<HotelDiscounts>> GetAllDiscount()
        {
            return await _db.HotelDiscounts.ToListAsync();
        }

        public async Task<HotelDiscounts> UpdateHotelDiscount(HotelDiscounts hotelDiscounts)
        {
            var existingHotelDiscount = await _db.HotelDiscounts.FindAsync(hotelDiscounts.DiscountId);
            if (existingHotelDiscount == null)
            {
                throw new Exception("Hotel not found");
            }

            _db.Entry(existingHotelDiscount).CurrentValues.SetValues(hotelDiscounts);
            await _db.SaveChangesAsync();

            return hotelDiscounts;
        }
    }
}
