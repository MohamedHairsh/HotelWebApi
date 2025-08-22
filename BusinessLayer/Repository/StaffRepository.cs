using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using AutoMapper;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class StaffRepository : IStaffRepository
    {

        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public StaffRepository(HotelDbContext db, IMapper mapper, IWebHostEnvironment env)
        {
            _db = db;
            _mapper = mapper;
            _env = env;
        }

        public async Task<string> CreateStaff(StaffDto staffDto)
        {
            var staff = _mapper.Map<Staff>(staffDto);
            staff.StaffId = Guid.NewGuid();
            staff.CreatedDate = DateTime.Now;
            staff.CreatedBy = Guid.NewGuid();

           
            if (staffDto.StaffImageFile != null && staffDto.StaffImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads/staff");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}_{staffDto.StaffImageFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await staffDto.StaffImageFile.CopyToAsync(stream);
                }

                staff.StaffImage = $"/uploads/staff/{fileName}";
            }

            _db.Staffs.Add(staff);
            await _db.SaveChangesAsync();
            return "Successfully saved staff record.";
        }



       

        public Task<Staff> GetAllById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Staff>> GetAllStaff()
        {
            var staff = _db.Staffs.ToList();
            return Task.FromResult(staff);
        }

         public async Task<StaffDto> UpdateStaff(Guid id, StaffDto staffDto)
    {
        var staff = await _db.Staffs.FindAsync(id);
        if (staff == null) return null;

        staff.FirstName = staffDto.FirstName;
        staff.LastName = staffDto.LastName;
        staff.PhoneNumber = staffDto.PhoneNumber;
        staff.DateOfBirth = staffDto.DateOfBirth;
        staff.Address = staffDto.Address;
        staff.Email = staffDto.Email;
        staff.Gender = staffDto.Gender;
        staff.JoiningDate = staffDto.JoiningDate;
        staff.ModifiedDate = DateTime.Now;
        staff.ModifiedBy = Guid.NewGuid();

      
        if (staffDto.StaffImageFile != null && staffDto.StaffImageFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads/staff");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}_{staffDto.StaffImageFile.FileName}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await staffDto.StaffImageFile.CopyToAsync(stream);
            }

            staff.StaffImage = $"/uploads/staff/{fileName}";
        }

        _db.Staffs.Update(staff);
        await _db.SaveChangesAsync();

        return _mapper.Map<StaffDto>(staff);
    }

        public async Task DeleteStaff(Guid id)
        {
            var Staff = await _db.Staffs.FindAsync(id);
            if (Staff != null)
            {
                _db.Staffs.Remove(Staff);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Staff Details not found");
            }
        }
    }
}
