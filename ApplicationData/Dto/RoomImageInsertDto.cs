using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class RoomImageInsertDto
    {
        [Required]
        public string? HotelId { get; set; }

        [MaxLength(50)]
        public string? RoomType { get; set; }

        [MaxLength(100)]
        public string? RoomName { get; set; }

        [MaxLength(50)]
        public string? BedType { get; set; }

        public int? MaxAdults { get; set; }

        public int? MaxChildren { get; set; }

        [MaxLength(20)]
        public string? RoomSize { get; set; }

        public decimal? BasePrice { get; set; }

        [MaxLength(50)]
        public string? RoomStatus { get; set; }

        [MaxLength(50)]
        public string? RefundPolicy { get; set; }

        public bool? BreakfastIncluded { get; set; }

        public int? AvailableRooms { get; set; }

        public IFormFile[]? RoomImagesJson { get; set; }
    }


    public class RoomImageUpdateDto  : RoomImageInsertDto
    {
        public int Id { get; set; }
    }
}
