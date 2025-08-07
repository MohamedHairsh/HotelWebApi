using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelNearbyLandmark
    {
        [Key]
        public Guid LandmarkId { get; set; }
        public Guid HotelId { get; set; }
        public string LandmarkName { get; set; } = string.Empty;
        public decimal DistanceInKm { get; set; }
        public string LandmarkType { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}