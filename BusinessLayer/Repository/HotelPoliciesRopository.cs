using ApplicationLayer.AppDbContexts;
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
    public class HotelPoliciesRopository : IHotelPoliciesRopository
    {
        private readonly HotelDbContext _db;
        public HotelPoliciesRopository(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<string> CreateHotelPolicies(HotelPolicies hotelpolicies)
        {
            hotelpolicies.PolicyId = Guid.NewGuid();
          
            _db.HotelPolicies.Add(hotelpolicies);
            await _db.SaveChangesAsync();
            return "HotelPolicies Created Successfully";
        }

        public async Task DeleteHotelPolicies(Guid id)
        {
            var hotelpolicies = await _db.HotelPolicies.FindAsync(id);
            if (hotelpolicies != null)
            {
                _db.HotelPolicies.Remove(hotelpolicies);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("HotelPolicies not found");
            }
        }

        public async Task<List<HotelPolicies>> GetAllById(Guid id)
        {
            return await _db.HotelPolicies
                           .Where(h => h.PolicyId == id)
                           .ToListAsync();
        }

        public async Task<List<HotelPolicies>> GetAllHotelPolicies()
        {
            return await _db.HotelPolicies.ToListAsync();
        }

        public async Task<HotelPolicies> UpdateHotelPolicies(HotelPolicies hotelpolicies)
        {
            var existingHotel = await _db.HotelPolicies.FindAsync(hotelpolicies.PolicyId);
            if (existingHotel == null)
            {
                throw new Exception("HotelPolicies not found");
            }

            _db.Entry(existingHotel).CurrentValues.SetValues(hotelpolicies);
            await _db.SaveChangesAsync();

            return hotelpolicies;
        }
    }
}
