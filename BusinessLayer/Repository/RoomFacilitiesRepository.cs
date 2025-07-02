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
    public class RoomFacilitiesRepository : IRoomFacilitiesRepository
    {
        private readonly HotelDbContext _db;

        public RoomFacilitiesRepository(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<string> CreateRoomFacilities(RoomFacilities roomFacilities)
        {
            roomFacilities.RoomFacilityId = Guid.NewGuid();
            _db.RoomFacilities.Add(roomFacilities);
            await _db.SaveChangesAsync();
            return "RoomFacilities Created Successfully";
        }

        public async Task DeleteRoomFacilites(Guid id)
        {
            var roomFacilities = await _db.RoomFacilities.FindAsync(id);
            if (roomFacilities != null)
            {
                _db.RoomFacilities.Remove(roomFacilities);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("RoomFacilities not found");
            }
        }

        public async Task<List<RoomFacilities>> GetAllByIdRoomFacilities(Guid id)
        {
            return await _db.RoomFacilities
                            .Where(h => h.RoomFacilityId == id)
                            .ToListAsync();
        }

        public async Task<List<RoomFacilities>> GetAllRoomFacilities()
        {
            return await _db.RoomFacilities.ToListAsync();
        }

        public async Task<RoomFacilities> UpdateRoomFacilities(RoomFacilities roomFacilities)
        {
            var existingHotel = await _db.RoomFacilities.FindAsync(roomFacilities.RoomFacilityId);
            if (existingHotel == null)
            {
                throw new Exception("RoomFacilities not found");
            }

            _db.Entry(existingHotel).CurrentValues.SetValues(roomFacilities);
            await _db.SaveChangesAsync();

            return roomFacilities;
        }
    }
}
