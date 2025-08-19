using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using ApplicationLayer.Models.Enum;

namespace BusinessLayer.IRepository
{
    public interface IRoomRepository
    {
        Task<string> CreateRoom(HotelRoomDto roomDto);
        Task<List<HotelRoom>> GetAllRoom();
        Task<List<HotelRoom>> GetAllById(Guid id);

        Task<HotelRoomDto> UpdateHotel(Guid id, HotelRoomDto roomDto);

        Task DeleteHotel(Guid id);
        Task<string> AddRoomType(MasterRoomDto masterRoom);
        Task<List<MasterRoom>> GetRoomType();

        Task<string> AddBedType(MasterBedDto masterBed);
        Task<List<MasterBed>> GetBedType();
        Task<bool> DeleteMasterAsync (MasterType masterType,Guid id);
        Task<bool> UpdateMasterAsync (MasterType masterType, Guid id, string name);
    }
}
