using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;

namespace BusinessLayer.IRepository
{
    public interface IHotelImagesRepository
    {

        Task<string> CreateHotelImages(HotelImageInsertDto hotelImages);
        Task<List<HotelImages>> GetAllHotelImagesl();
        Task<List<HotelImages>> GetAllById(Guid id);

        Task<string> UpdateHotelImages(HotelImageUpdateDto hotelImages);
        Task DeleteHotelImages(int id);
    }
}
