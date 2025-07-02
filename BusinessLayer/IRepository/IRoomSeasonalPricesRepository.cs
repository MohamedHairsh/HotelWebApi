using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IRoomSeasonalPricesRepository
    {
        Task<string> CreateRoomSeasonalPrices(RoomSeasonalPrices roomSeasonalPrices);
        Task<List<RoomSeasonalPrices>> GetAllRoomSeasonalPrices();
        Task<List<RoomSeasonalPrices>> GetAllByIdRoomSeasonalPrices(Guid id);
        Task<RoomSeasonalPrices> UpdateRoomSeasonalPrices(RoomSeasonalPrices roomSeasonalPrices);
        Task DeleteRoomSeasonalPrices(Guid id);
    }
}
