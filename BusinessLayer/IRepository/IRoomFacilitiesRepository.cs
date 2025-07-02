using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IRoomFacilitiesRepository
    {
        Task<string> CreateRoomFacilities(RoomFacilities roomFacilities);
        Task<List<RoomFacilities>> GetAllRoomFacilities();
        Task<List<RoomFacilities>> GetAllByIdRoomFacilities(Guid id);

        Task<RoomFacilities> UpdateRoomFacilities(RoomFacilities roomFacilities);
        Task DeleteRoomFacilites(Guid id);
    }
}
