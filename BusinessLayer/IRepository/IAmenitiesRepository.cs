using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IAmenitiesRepository
    {
        Task<string> CreateAmenities(AmenitiesDto amenitiesDto);
        Task<List<Amenities>> GetAllAmenities();
        Task<Amenities> GetAllById(Guid id);
        Task<AmenitiesDto> UpdateAmenities(Guid id, AmenitiesDto amenitiesDto);
        Task DeleteAmenities(Guid id);
      
    }
}
