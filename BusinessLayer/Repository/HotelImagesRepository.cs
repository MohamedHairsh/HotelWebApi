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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository
{
    public class HotelImagesRepository : IHotelImagesRepository
    {
        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;
        public HotelImagesRepository(HotelDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<string> CreateHotelImages(HotelImageInsertDto hotelImages)
        {
            try
            {
                if (hotelImages.ImageFile == null || hotelImages.ImageFile.Length == 0)
                    return "No image file uploaded.";

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "hotels");
                Directory.CreateDirectory(uploadPath);

                var commonImageId = Guid.NewGuid();

                foreach (var formFile in hotelImages.ImageFile)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
                        var filePath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        var hotelImage = new HotelImages
                        {
                            ImageId = commonImageId,   //--> Same ID for all images in this upload
                            HotelId = hotelImages.HotelId,
                            ImageUrl = $"/images/hotels/{fileName}",
                            Description = hotelImages.Description,
                            IsPrimary = hotelImages.IsPrimary
                        };

                        _db.HotelImages.Add(hotelImage);
                    }
                }

                await _db.SaveChangesAsync();

                return "Hotel images uploaded and saved successfully.";
            }
            catch (Exception ex)
            {
                // Optional: log exception here
                return $"An error occurred: {ex.Message}";
            }
        }




        public async Task DeleteHotelImages(int id)
        {
            var hotelImg = await _db.HotelImages.FindAsync(id);
            if (hotelImg != null)
            {
                _db.HotelImages.Remove(hotelImg);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("HotelImages not found");
            }
        }

        public async Task<List<HotelImages>> GetAllById(Guid id)
        {
            return await _db.HotelImages.Where(h=>h.ImageId == id).ToListAsync();
        }

        public async Task<List<HotelImages>> GetAllHotelImagesl()
        {
           var data = await _db.HotelImages.ToListAsync();
           return _mapper.Map<List<HotelImages>>(data);
        }

        public async Task<string> UpdateHotelImages(HotelImageUpdateDto hotelImages)
        {
            try
            {
                if ( hotelImages.Id <= 0)
                    return "Invalid ImageId or HotelId.";

                var images = _db.HotelImages
                    .Where(img => img.Id == hotelImages.Id)
                    .ToList();

                if (!images.Any())
                    return "No images found to update.";

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "hotels");
                Directory.CreateDirectory(uploadPath);

                int fileIndex = 0;

                foreach (var image in images)
                {
                    if (hotelImages.ImageFile != null && hotelImages.ImageFile.Length > fileIndex)
                    {
                        var newFile = hotelImages.ImageFile[fileIndex];

                        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                            System.IO.File.Delete(oldFilePath);

                        var fileName = Guid.NewGuid() + Path.GetExtension(newFile.FileName);
                        var filePath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await newFile.CopyToAsync(stream);
                        }

                        image.ImageUrl = $"/images/hotels/{fileName}";
                        fileIndex++;
                    }

                    // Update metadata
                    image.Description = hotelImages.Description;
                    image.IsPrimary = hotelImages.IsPrimary;

                    _db.HotelImages.Update(image);
                }

                await _db.SaveChangesAsync();

                return "Hotel images updated successfully.";
            }
            catch (Exception ex)
            {
                return $"An error occurred while updating hotel images: {ex.Message}";
            }
        }

    }
}
