using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class RoomFacilities
    {
        [Key]
        public Guid RoomFacilityId { get; set; }
        public string? RoomId { get; set; }
        public string? FacilityId { get; set; }
    }
}
