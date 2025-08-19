using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelImage
    {
        [Key]
        public Guid ImageId { get; set; }
        public Guid HotelId { get; set; }
        public string ImageUrl  { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}