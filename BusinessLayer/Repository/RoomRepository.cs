using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.AppDbContexts;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using ApplicationLayer.Models.Enum;
using AutoMapper;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLayer.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _db;
        private readonly IMapper _mapper;
        public RoomRepository(HotelDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<string> CreateRoom(HotelRoomDto roomDto)
        {
            var room = _mapper.Map<HotelRoom>(roomDto);
            room.RoomId = Guid.NewGuid();
            room.CreatedDate = DateTime.Now;
            room.HotelId = roomDto.HotelId;

            _db.HotelRooms.Add(room);
            await _db.SaveChangesAsync();

            return "Room Created Successfully";
        }

        public async Task DeleteHotel(Guid id)
        {
            var room = await _db.HotelRooms.FindAsync(id);

            if (room != null)
            {
               _db.HotelRooms.Remove(room);
                await _db.SaveChangesAsync();

            }
            else
            {
                throw new Exception("Rooms not found");
            }
        }



        public async Task<List<HotelRoom>> GetAllRoom()
        {
            return await (from a in _db.HotelRooms
                          join b in _db.MasterRoom on a.RoomType equals b.RoomType
                          join c in _db.MasterBed on a.BedType equals c.BedType
                          
                          select a).ToListAsync();
        }


        public async Task<List<HotelRoom>> GetAllById(Guid id)
        {
            return await (from a in _db.HotelRooms
                          join b in _db.MasterRoom on a.RoomType equals b.RoomType
                          join c in _db.MasterBed on a.BedType equals c.BedType
                          where a.RoomId == id
                          select a).ToListAsync();
        }

        //public async Task<List<HotelRoom>> GetAllById(Guid id)
        //{
        //    var hotelrooms = await _db.HotelRooms
        //                          .Where(h => h.RoomId == id)
        //                          .ToListAsync();

        //    return _mapper.Map<List<HotelRoom>>(hotelrooms);
        //}





        public async Task<HotelRoomDto> UpdateHotel(Guid id, HotelRoomDto roomDto)
        {
            var existingRoom = await _db.HotelRooms.FirstOrDefaultAsync(x=>x.RoomId==id);
            if (existingRoom == null)
            {
                throw new Exception("Rooms not found");
            }
            existingRoom.ModifiedDate= DateTime.Now;
            existingRoom.ModifiedBy = roomDto.HotelId;
            _mapper.Map(roomDto , existingRoom);
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelRoomDto>(existingRoom);
        }

        public async Task<string> AddRoomType(MasterRoomDto masterRoom)
        {
            if (string.IsNullOrWhiteSpace(masterRoom.RoomType))
            {
                return "Enter the RoomType";
            }
            var data=_mapper.Map<MasterRoom>(masterRoom);
            data.RoomID = new Guid();

            _db.MasterRoom.Add(data);
            await _db.SaveChangesAsync();
           
            return "Roomtype added successfully";

        }

        public async Task<List<MasterRoom>> GetRoomType()
        {
            var data = await _db.MasterRoom.ToListAsync();
            return _mapper.Map<List<MasterRoom>>(data);
        }

        public async Task<string> AddBedType(MasterBedDto masterBed)
        {
            if (string.IsNullOrWhiteSpace(masterBed.BedType))
            {
                return "Enter the RoomType";
            }

            var data = _mapper.Map<MasterBed>(masterBed);
            data.BedID = new Guid();

            _db.MasterBed.Add(data);

            await _db.SaveChangesAsync();

            return "Bedtype added successfully";

        }

        public async Task<List<MasterBed>> GetBedType()
        {
            var data = await _db.MasterBed.ToListAsync();
            return _mapper.Map<List<MasterBed>>(data);
        }
        public async Task<bool> DeleteMasterAsync(MasterType masterType,Guid id)
        {
            switch(masterType)
            {
                case MasterType.Room:
                
                        var room = await _db.MasterRoom.FindAsync(id);
                        if (room == null)
                            return false;
                        _db.MasterRoom.Remove(room);
                    break;

                case MasterType.Bed:
                    var bed = await _db.MasterBed.FindAsync(id);
                    if(bed == null) 
                        return false;
                    _db.MasterBed.Remove(bed);
                    break;

                    default:
                      return false;

            }

            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateMasterAsync(MasterType masterType, Guid id, string name)
        {
           switch (masterType)
            {
                case MasterType.Room:
                    var room = await _db.MasterRoom.FindAsync(id);
                    if (room == null) return false;
                    room.RoomType = name; 
                    break;

                case MasterType.Bed:
                    var bed = await _db.MasterBed.FindAsync(id);
                    if (bed == null) return false;
                    bed.BedType = name;
                    break;

                default:
                  return false;
            }

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
