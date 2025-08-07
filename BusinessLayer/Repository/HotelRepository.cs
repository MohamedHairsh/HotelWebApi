using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using AutoMapper;
using BusinessLayer.IRepository;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;

        public HotelRepository(HotelDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<string> CreateHotel(HotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto); 
            hotel.HotelId = Guid.NewGuid();
            hotel.CreatedDate = DateTime.UtcNow;
            hotel.CreatedBy = hotelDto.HotelAdminId;

            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();

            return "Hotel Created Successfully";
        }

        public async Task DeleteHotel(Guid id)
        {
            var hotel = await _db.Hotels.FindAsync(id);
            
            if (hotel != null)
            {
                hotel.IsActive = false;
                await _db.SaveChangesAsync();
               
            }
            else
            {
                throw new Exception("Hotel not found");
            }
        }

        public async Task<List<Hotel>> GetAllById(Guid id)
        {
            var hotels = await _db.Hotels
                                  .Where(h => h.HotelId == id)
                                  .ToListAsync();

            return _mapper.Map<List<Hotel>>(hotels); 
        }

        public async Task<List<Hotel>> GetAllHotel()
        {
            var hotels = await _db.Hotels.ToListAsync();
            var query = from a in hotels
                        where a.IsActive == true
                        select a;
            return _mapper.Map<List<Hotel>>(query); 
        }

        public async Task<HotelDto> UpdateHotel(Guid id, HotelDto hotelDto)
        {
            var existingHotel = await _db.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);
            if (existingHotel == null)
            {
                throw new Exception("Hotel not found");
            }

            existingHotel.ModifiedDate = DateTime.UtcNow;
            existingHotel.ModifiedBy = hotelDto.HotelAdminId;

            _mapper.Map(hotelDto, existingHotel);

            await _db.SaveChangesAsync();

            return _mapper.Map<HotelDto>(existingHotel);
        }

    }
}
