using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using AutoMapper;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BusinessLayer.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;
        public BookingRepository(HotelDbContext db, IMapper mapper)
        {
                _db = db;
                _mapper = mapper;
        }
        public async Task<string> CreateBooking(BookingDto bookingDto)
         {
           var book=_mapper.Map<Booking>(bookingDto);
            book.BookingId =Guid.NewGuid();
            book.CreatedDate=DateTime.Now;

            _db.Bookings.Add(book);
            await _db.SaveChangesAsync();
            return "Successfully Booked";
        }

        public async Task DeleteBooking(Guid id)
        {
            var book = await  _db.Bookings.FindAsync(id);
            if (book !=null)
            {
                _db.Bookings.Remove(book);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Booking Details not found");
            }
        }

        public async Task<List<Booking>> GetAllBooking()
        {
            var book = await _db.Bookings.ToListAsync();
            return _mapper.Map<List<Booking>>(book);
        }

        public Task<Booking> GetAllById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDto> UpdateBooking(Guid id, BookingDto bookingDto)
        {
            throw new NotImplementedException();
        }
    }
}
