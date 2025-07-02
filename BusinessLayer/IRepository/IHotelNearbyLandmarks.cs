using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IHotelNearbyLandmarks
    {
          Task<string> CreateHotelNearbyLandmarks(HotelNearbyLandmarks hotelLandmarks);
        Task<List<HotelNearbyLandmarks>> GetAllHotelNearbyLandmarks();
        Task<List<HotelNearbyLandmarks>> GetAllById(Guid id);
        Task<HotelNearbyLandmarks> UpdateHotelNearbyLandmarks(HotelNearbyLandmarks hoteLandmarks);
        Task DeleteHoteLandMark(Guid id);
    }
}
