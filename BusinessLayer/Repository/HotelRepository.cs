using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Models;
using AutoMapper;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;
        public HotelRepository(HotelDbContext db,IMapper mapper)
        {
            _db= db;
            _mapper= mapper;
        }
        public async Task<string> CreateHotel(Hotels hotels)
        {
            hotels.HotelId = Guid.NewGuid();
            hotels.CreatedDate = DateTime.UtcNow;
            _db.Hotels.Add(hotels);
            await _db.SaveChangesAsync();
            return "Hotel Created Successfully";

        }

        public async Task DeleteHotel(Guid id)
        {
            var hotel = await _db.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _db.Hotels.Remove(hotel);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hotel not found");
            }
        }

        public async Task<List<Hotels>> GetAllById(Guid id)
        {
            var data=await _db.Hotels
                            .Where(h => h.HotelId == id)
                            .ToListAsync();
            return data;
        }

        public async Task<List<Hotels>> GetAllHotel()
        {
            return await _db.Hotels.ToListAsync();
        }

        public async Task<Hotels> UpdateHotel(Hotels hotels)
        {
            var existingHotel = await _db.Hotels.FindAsync(hotels.HotelId);
            if (existingHotel == null)
            {
                throw new Exception("Hotel not found");
            }

            _db.Entry(existingHotel).CurrentValues.SetValues(hotels);
            await _db.SaveChangesAsync();

            return hotels;
        }
    }
}
