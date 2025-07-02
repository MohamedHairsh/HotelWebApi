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
    public class RoomSeasonalPricesRepository : IRoomSeasonalPricesRepository
    {
        private readonly HotelDbContext _db;

        public RoomSeasonalPricesRepository(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<string> CreateRoomSeasonalPrices(RoomSeasonalPrices roomSeasonalPrices)
        {
            roomSeasonalPrices.SeasonalPriceId = Guid.NewGuid();
            roomSeasonalPrices.StartDate = roomSeasonalPrices.StartDate;
            roomSeasonalPrices.EndDate = roomSeasonalPrices.EndDate;
            _db.RoomSeasonalPrices.Add(roomSeasonalPrices);
            await _db.SaveChangesAsync();
            return "RoomSeasonalPrices Created Successfully";
        }

        public async Task DeleteRoomSeasonalPrices(Guid id)
        {
            var roomSeasonalPrices = await _db.RoomSeasonalPrices.FindAsync(id);
            if (roomSeasonalPrices != null)
            {
                _db.RoomSeasonalPrices.Remove(roomSeasonalPrices);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("RoomSeasonalPrices not found");
            }
        }

        public async Task<List<RoomSeasonalPrices>> GetAllByIdRoomSeasonalPrices(Guid id)
        {
            return await _db.RoomSeasonalPrices
                            .Where(h => h.SeasonalPriceId == id)
                            .ToListAsync();
        }

        public async Task<List<RoomSeasonalPrices>> GetAllRoomSeasonalPrices()
        {
            return await _db.RoomSeasonalPrices.ToListAsync();
        }

        public async Task<RoomSeasonalPrices> UpdateRoomSeasonalPrices(RoomSeasonalPrices roomSeasonalPrices)
        {
            var existingHotel = await _db.RoomSeasonalPrices.FindAsync(roomSeasonalPrices.SeasonalPriceId);
            if (existingHotel == null)
            {
                throw new Exception("RoomSeasonalPrices not found");
            }

            _db.Entry(existingHotel).CurrentValues.SetValues(roomSeasonalPrices);
            await _db.SaveChangesAsync();

            return roomSeasonalPrices;
        }
    }
}
