using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelFacilities
    {
        [Key]
        public Guid HotelFacilityId { get; set; }
        public string? HotelId { get; set; }
        public string? FacilityId { get; set; }

        public bool IsAvailable { get; set; }

    }
}
