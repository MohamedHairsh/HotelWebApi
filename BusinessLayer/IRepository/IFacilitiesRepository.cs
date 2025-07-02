using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IFacilitiesRepository
    {

        Task<string> CreateHotelFacilities(Facilities  facilities);
        Task<List<Facilities>> GetAllFacilities();
        Task<List<Facilities>> GetAllById(Guid id);

        Task<Facilities> UpdateHotelFacilities(Facilities facilities);
        Task DeleteHotelFacilities(Guid id);
    }
}
