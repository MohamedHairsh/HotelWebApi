using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IRoomAvailabilityRepository
    {
        Task<string> CreateRoomAvailability(RoomAvailability roomAvailability);
        Task<List<RoomAvailability>> GetAllRoomAvailability();
        Task<List<RoomAvailability>> GetAllByIdRoomAvailability(Guid id);

        Task<RoomAvailability> UpdateRoomAvailability(RoomAvailability roomAvailability);
        Task DeleteRoomAvailability(Guid id);
    }
}
