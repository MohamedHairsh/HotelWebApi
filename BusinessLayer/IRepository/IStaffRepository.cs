using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IStaffRepository
    {
        Task<string> CreateStaff(StaffDto staffDto);
        Task<List<Staff>> GetAllStaff();
        Task<Staff> GetAllById(Guid id);
        Task<StaffDto> UpdateStaff(Guid id, StaffDto staffDto);
        Task DeleteStaff(Guid id);
    }
}
