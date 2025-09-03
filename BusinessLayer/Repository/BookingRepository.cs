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



        public async Task<Booking> GetAllById(Guid id)
        {
            var booking = await _db.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);

            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with Id {id} not found.");
            }

            return booking;
        }




        public async Task<BookingDto> UpdateBooking(Guid id, BookingDto bookingDto)
        {
            var existingBooking = await _db.Bookings.FindAsync(id);

            if (existingBooking == null)
            {
                throw new Exception("Booking not found");
            }

           
            _mapper.Map(bookingDto, existingBooking);

            existingBooking.ModifiedDate = DateTime.Now;
            existingBooking.ModifiedDate = DateTime.Now;

            _db.Bookings.Update(existingBooking);
            await _db.SaveChangesAsync();

            return _mapper.Map<BookingDto>(existingBooking);
        }

    }
}
