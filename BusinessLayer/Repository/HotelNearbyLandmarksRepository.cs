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
    public class HotelNearbyLandmarksRepository : IHotelNearbyLandmarks
    {


        private readonly HotelDbContext _db;// Dependency Injection 

        public HotelNearbyLandmarksRepository(HotelDbContext db) // Constructor DI
        {
            _db = db;
        }
        
       

        public async Task<string> CreateHotelNearbyLandmarks(HotelNearbyLandmarks hotelLandmarks)
        {
            hotelLandmarks.LandmarkId = Guid.NewGuid();
            //hotels.CreatedDate = DateTime.UtcNow;
            _db.HotelNearbyLandmarks.Add(hotelLandmarks);
            await _db.SaveChangesAsync();
            return "HotelLandMark Is Created Successfully";
        }


        public async Task DeleteHoteLandMark(Guid id)
        {
            var hotelLandMark = await _db.HotelNearbyLandmarks.FindAsync(id);
            if (hotelLandMark != null)
            {
                _db.HotelNearbyLandmarks.Remove(hotelLandMark);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("HotelLandMark is not found");
            }
        }

        //public Task<List<HotelNearbyLandmarks>> GetAllById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}



        public async Task<List<HotelNearbyLandmarks>> GetAllById(Guid id)
        {
            //return await _db.HotelNearbyLandmarks
            //                .Where(h => h.HotelId == id)
            //                .ToListAsync();

            return await _db.HotelNearbyLandmarks.Where(h => h.LandmarkId == id)
                           .ToListAsync();
        }
      


        //public async Task<List<HotelNearbyLandmarks>> GetAllHotelNearbyLandmarks()
        //{
        //    return await _db.HotelNearbyLandmarks.ToListAsync();
        //}

       

        public async Task<List<HotelNearbyLandmarks>> GetAllHotelNearbyLandmarks()
        {
            return await _db.HotelNearbyLandmarks.ToListAsync();
        }


        // IHotelLandMarkRepository
        // HotelRepository
        // Controller


        //public async Task<HotelNearbyLandmarks> UpdateHotelNearbyLandmarks(HotelNearbyLandmarks hotelNearbyLandmarks)
        //{
        //    var existingHotel = await _db.HotelNearbyLandmarks.FindAsync(hotelNearbyLandmarks.LandmarkId);
        //    if (existingHotel == null)
        //    {
        //        throw new Exception("Hotel not found");
        //    }

        //    _db.Entry(existingHotel).CurrentValues.SetValues(existingHotel);
        //    await _db.SaveChangesAsync();

        //    return existingHotel;
        //}

        public async Task<HotelNearbyLandmarks> UpdateHotelNearbyLandmarks(HotelNearbyLandmarks hotelNearbyLandmarks)
        {
            var existingLandMark = await _db.HotelNearbyLandmarks.FindAsync(hotelNearbyLandmarks.LandmarkId);
            if (existingLandMark == null)
            {
                throw new Exception("HotelLandMark not found");
            }

            _db.Entry(existingLandMark).CurrentValues.SetValues(hotelNearbyLandmarks);
            await _db.SaveChangesAsync();

            return hotelNearbyLandmarks;
        }

    }



}
