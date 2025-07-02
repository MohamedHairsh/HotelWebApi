using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class HotelRoomsRepository : IHotelRoomsRepository
    {
        private readonly HotelDbContext _db;

        public HotelRoomsRepository(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<string> CreateHotelRooms(RoomImageInsertDto roomImg)
        {
            try
            {
                if (roomImg.RoomImagesJson == null || roomImg.RoomImagesJson.Length == 0)
                    return "No image file uploaded.";

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "hotelRooms");
                Directory.CreateDirectory(uploadPath);

                var commonImageId = Guid.NewGuid();

                foreach (var formFile in roomImg.RoomImagesJson)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
                        var filePath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        var room = new HotelRooms
                        {
                            RoomId = commonImageId,   
                            HotelId = roomImg.HotelId,
                            RoomName = roomImg.RoomName,
                            BedType = roomImg.BedType,
                            MaxAdults = roomImg.MaxAdults,
                            MaxChildren = roomImg.MaxChildren,
                            RoomSize = roomImg.RoomSize,
                            BasePrice = roomImg.BasePrice,
                            RoomStatus = roomImg.RoomStatus,
                            RefundPolicy = roomImg.RefundPolicy,
                            BreakfastIncluded = roomImg.BreakfastIncluded,
                            AvailableRooms = roomImg.AvailableRooms,
                            RoomImagesJson=$"/images/hotelRooms/{fileName}"

                           
                        };

                        _db.HotelRooms.Add(room);
                    }
                }

                await _db.SaveChangesAsync();

                return "Rooms Data's saved successfully.";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }

        public async Task DeleteHotelRooms(Guid id)
        {
            var hotelrooms = await _db.HotelRooms.FindAsync(id);
            if (hotelrooms != null)
            {
                _db.HotelRooms.Remove(hotelrooms);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hotel not found");
            }
        }

        public async Task<List<HotelRooms>> GetAllById(Guid id)
        {
            return await _db.HotelRooms
                            .Where(h => h.RoomId == id)
                            .ToListAsync();
        }

        public async Task<List<HotelRooms>> GetAllHotelRooms()
        {
            return await _db.HotelRooms.ToListAsync();
        }

        public async Task<string> UpdateHotelRooms(RoomImageUpdateDto roomImg)
        {
            try
            {
                if (roomImg.Id <= 0)
                    return "Invalid ImageId or HotelId.";

                var images = _db.HotelRooms
                    .Where(img => img.Id == roomImg.Id)
                    .ToList();

                if (!images.Any())
                    return "No images found to update.";

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "hotelRooms");
                Directory.CreateDirectory(uploadPath);

                int fileIndex = 0;

                foreach (var data in images)
                {
                    if (roomImg.RoomImagesJson != null && roomImg.RoomImagesJson.Length > fileIndex)
                    {
                        var newFile = roomImg.RoomImagesJson[fileIndex];

                        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", data.RoomImagesJson.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                            System.IO.File.Delete(oldFilePath);

                        var fileName = Guid.NewGuid() + Path.GetExtension(newFile.FileName);
                        var filePath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await newFile.CopyToAsync(stream);
                        }

                        data.RoomImagesJson = $"/images/hotelRooms/{fileName}";
                        fileIndex++;
                    }

                    // Update metadata
                   data.RoomType = roomImg.RoomType;
                    data.RoomName = roomImg.RoomName;
                    data.BedType = roomImg.BedType;
                    data.MaxAdults = roomImg.MaxAdults;
                    data.MaxChildren = roomImg.MaxChildren;
                    data.RoomSize = roomImg.RoomSize;   
                    data.BasePrice = roomImg.BasePrice;
                    data.RoomStatus = roomImg.RoomStatus;
                    data.RefundPolicy = roomImg.RefundPolicy;
                    data.BreakfastIncluded = roomImg.BreakfastIncluded;
                    data.AvailableRooms = roomImg.AvailableRooms;

                    _db.HotelRooms.Update(data);
                }

                await _db.SaveChangesAsync();

                return "Room Data's updated successfully.";
            }
            catch (Exception ex)
            {
                return $"An error occurred while updating hotel images: {ex.Message}";
            }
        }
    }
}
