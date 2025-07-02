using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IHotelDiscountRepository
    {
        Task<string> CreateHotelDiscount(HotelDiscounts hotelDiscounts);
        Task<List<HotelDiscounts>> GetAllDiscount();
        Task<List<HotelDiscounts>> GetAllById(Guid id);

        Task<HotelDiscounts> UpdateHotelDiscount(HotelDiscounts hotelDiscounts);
        Task DeleteHotelDiscount(Guid id);

    }
}
