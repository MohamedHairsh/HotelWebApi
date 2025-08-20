using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dto
{
    public class AmenitiesDto
    {

      

        public Guid AmenitiesId { get; set; }
        public string AmenitiesName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public string Status { get; set; } = string.Empty;

        // For uploading
        public IFormFile? AmenityImageFile { get; set; }

        // For saving the image path in DB
        public string? AmenityImage { get; set; }
    }
}
