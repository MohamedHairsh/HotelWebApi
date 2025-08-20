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
    public class AmenitiesRepository : IAmenitiesRepository
    {

        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;

       
        public AmenitiesRepository(HotelDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<string> CreateAmenities(AmenitiesDto amenitiesDto)
        {
            var amenities = _mapper.Map<Amenities>(amenitiesDto);
            amenities.AmenitiesId = Guid.NewGuid();
            amenities.CreatedDate = DateTime.Now;
            amenities.CreatedBy = Guid.NewGuid(); 

            _db.Amenities.Add(amenities);
            await _db.SaveChangesAsync();
            return "Successfully saved amenities record.";
        }


       

        

        public async Task<List<Amenities>> GetAllAmenities()
        {
            var amenities = await _db.Amenities.ToListAsync();
            return _mapper.Map<List<Amenities>>(amenities);
        }

        public async Task DeleteAmenities(Guid id)
        {
            var Amety = await _db.Amenities.FindAsync(id);
            if (Amety != null)
            {
                _db.Amenities.Remove(Amety);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Booking Details not found");
            }
        }

        public Task<Amenities> GetAllById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AmenitiesDto> UpdateAmenities(Guid id, AmenitiesDto amenitiesDto)
        {
            var existingAmenity = await _db.Amenities.FindAsync(id);
            if (existingAmenity == null)
            {
                throw new Exception("Amenities not found");
            }


            existingAmenity.AmenitiesName = amenitiesDto.AmenitiesName;
            existingAmenity.Description = amenitiesDto.Description;
            existingAmenity.OpeningTime = amenitiesDto.OpeningTime;
            existingAmenity.ClosingTime = amenitiesDto.ClosingTime;
            existingAmenity.Status = amenitiesDto.Status;
            existingAmenity.CreatedDate = DateTime.Now;


            if (!string.IsNullOrEmpty(amenitiesDto.AmenityImage))
            {
                existingAmenity.AmenityImage = amenitiesDto.AmenityImage;
            }

            _db.Amenities.Update(existingAmenity);
            await _db.SaveChangesAsync();

            return _mapper.Map<AmenitiesDto>(existingAmenity);
        }

    }
}
