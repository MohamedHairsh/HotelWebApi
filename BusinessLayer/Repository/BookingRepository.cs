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
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BusinessLayer.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;
      
        private readonly IWebHostEnvironment _env;
        public BookingRepository(HotelDbContext db, IMapper mapper,IWebHostEnvironment env)
        {
                _db = db;
                _mapper = mapper;
            _env = env;
        }
        


        public async Task<string> CreateBooking(BookingDto bookingDto)
        {

            var booking = _mapper.Map<Booking>(bookingDto);
            booking.BookingId = Guid.NewGuid();
            booking.CreatedDate = DateTime.Now;
            booking.CreatedBy = Guid.NewGuid();

            if (bookingDto.BookingImageFile != null && bookingDto.BookingImageFile.Length > 0)
            {
                var fileupload = Path.Combine(_env.WebRootPath, "uploads,Booking");
                if (!Directory.Exists(fileupload))
                    Directory.CreateDirectory(fileupload);
                var fileName = $"{Guid.NewGuid()}_{bookingDto.BookingImageFile.FileName}";
                var filepath = Path.Combine(fileupload, fileName);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await bookingDto.BookingImageFile.CopyToAsync(stream);
                }
                booking.BookingImage = $"/uploads/Booking/{fileName}";
            }
            _db.Bookings.Add(booking);

            await _db.SaveChangesAsync();
            return "Booking Created Successfully";


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
            var booking = await _db.Bookings.FindAsync(id);
            if (booking == null) return null;
           
            booking.HotelId = bookingDto.HotelId;
            booking.RoomId = bookingDto.HotelId;
            booking.CheckInDate = bookingDto.CheckInDate;
            booking.CheckOutDate = bookingDto.CheckOutDate;
            booking.Adults = bookingDto.Adults;
            booking.Children = bookingDto.Children;
            booking.Status = bookingDto.Status;
            booking.Notes = bookingDto.Notes;
            booking.ModifiedDate = DateTime.Now;
            booking.ModifiedBy = Guid.NewGuid();
            if (bookingDto.BookingImageFile != null && bookingDto.BookingImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads/Booking");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}_{bookingDto.BookingImageFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await bookingDto.BookingImageFile.CopyToAsync(stream);
                }
                booking.BookingImage = $"/uploads/Booking/{fileName}";
            }
            _db.Bookings.Update(booking);
            await _db.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
        }




       


        public async Task<List<BookingDto>> GetBookingsByHotel(Guid hotelId)
        {
            var bookings = await _db.Bookings
                                    .Where(b => b.HotelId == hotelId)
                                    .ToListAsync();

            if (bookings == null || !bookings.Any())
                throw new KeyNotFoundException($"No bookings found for hotel with ID {hotelId}.");

           
            return bookings.Select(b => new BookingDto
            {
                BookingId = b.BookingId,
                UserId = b.UserId,
                HotelId = b.HotelId,
                RoomId = b.RoomId,
                CheckInDate = b.CheckInDate,
                CheckOutDate = b.CheckOutDate,
                Adults = b.Adults,
                Children = b.Children,
                Status = b.Status,
                Notes = b.Notes
            }).ToList();
        }

      // procedure is a block which is used to perfprm one or more tasks
      // which is used maily for  perform dml operation
    }
}
