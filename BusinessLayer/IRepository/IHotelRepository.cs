using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Models;

namespace BusinessLayer.IRepository
{
    public interface IHotelRepository
    {
        Task<string> CreateHotel(Hotels hotels);
        Task<List<Hotels>> GetAllHotel();
        Task<List<Hotels>> GetAllById(Guid id);

        Task<Hotels> UpdateHotel(Hotels hotels);
        Task DeleteHotel(Guid id);
     }
}
