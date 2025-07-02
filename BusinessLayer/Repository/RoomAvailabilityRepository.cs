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
    
    public class RoomAvailabilityRepository : IRoomAvailabilityRepository
    {
        private readonly HotelDbContext _db;

        public RoomAvailabilityRepository(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<string> CreateRoomAvailability(RoomAvailability roomAvailability)
        {
            roomAvailability.RoomId = Guid.NewGuid();
            roomAvailability.Date = roomAvailability.Date;
            _db.RoomAvailabilities.Add(roomAvailability);
            await _db.SaveChangesAsync();
            return "Room Availability Created Successfully";
        }

        public async Task DeleteRoomAvailability(Guid id)
        {
            var hotel = await _db.RoomAvailabilities.FindAsync(id);
            if (hotel != null)
            {
                _db.RoomAvailabilities.Remove(hotel);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Room Availabilities not found");
            }
        }

        public async Task<List<RoomAvailability>> GetAllByIdRoomAvailability(Guid id)
        {
            return await _db.RoomAvailabilities
                           .Where(h => h.RoomId == id)
                           .ToListAsync();
        }

        public async Task<List<RoomAvailability>> GetAllRoomAvailability()
        {
            return await _db.RoomAvailabilities.ToListAsync();
        }

        public async Task<RoomAvailability> UpdateRoomAvailability(RoomAvailability roomAvailability)
        {
            var existingHotel = await _db.RoomAvailabilities.FindAsync(roomAvailability.RoomId);
            if (existingHotel == null)
            {
                throw new Exception("Room Availability not found");
            }

            _db.Entry(existingHotel).CurrentValues.SetValues(roomAvailability);
            await _db.SaveChangesAsync();

            return roomAvailability;
        }
    }
}
