using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IHotelPoliciesRopository
    {
        Task<string> CreateHotelPolicies(HotelPolicies hotelpolicies);
        Task<List<HotelPolicies>> GetAllHotelPolicies();
        Task<List<HotelPolicies>> GetAllById(Guid id);

        Task<HotelPolicies> UpdateHotelPolicies(HotelPolicies hotelpolicies);
        Task DeleteHotelPolicies(Guid id);
    }
}
