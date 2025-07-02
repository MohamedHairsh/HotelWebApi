using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IHotelFacilitiesRepository 
    {

        Task<string> CreateHotelFacilities(HotelFacilities hotels);
        Task<List<HotelFacilities>> GetAllHotelFacilities();
        Task<List<HotelFacilities>> GetAllById(Guid id);

        Task<HotelFacilities> UpdateHotelFacilities(HotelFacilities hotels);
        Task DeleteHotelFacilities(Guid id);
    }
}
