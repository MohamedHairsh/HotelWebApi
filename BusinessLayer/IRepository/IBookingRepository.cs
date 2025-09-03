using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;

namespace BusinessLayer.IRepository
{
    public  interface IBookingRepository
    {
        Task<string> CreateBooking(BookingDto bookingDto);
        Task<List<Booking>> GetAllBooking();
        Task<Booking> GetAllById(Guid id);
        Task<BookingDto> UpdateBooking(Guid id, BookingDto bookingDto);
        Task DeleteBooking(Guid id);

        Task<List<BookingDto>> GetBookingsByHotel(Guid hotelId);
    }
}
