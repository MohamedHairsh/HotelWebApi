using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IHotelRoomsRepository
    {

         Task<string> CreateHotelRooms(RoomImageInsertDto roomImg);
         Task<List<HotelRooms>> GetAllHotelRooms();
        Task<List<HotelRooms>> GetAllById(Guid id);

        Task<string> UpdateHotelRooms(RoomImageUpdateDto roomImg);
        Task DeleteHotelRooms(Guid id);
    }
}
