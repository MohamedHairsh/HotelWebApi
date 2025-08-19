using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;

namespace BusinessLayer.IRepository
{
    public interface IHotelRepository
    {
        Task<string> CreateHotel(HotelDto hotels);
        Task<List<Hotel>> GetAllHotel();
        Task<List<Hotel>> GetAllById(Guid id);

        Task<HotelDto> UpdateHotel(Guid id, HotelDto hotelDto);
        Task DeleteHotel(Guid id);
     }
}
