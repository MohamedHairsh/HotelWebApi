using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class Amenities
    {
        [Key]
    
        public Guid AmenitiesId { get; set; }

        public string AmenitiesName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }
        public string Status { get; set; } = string.Empty;

        public string ?AmenityImage { get; set; }
        /// <summary>
        ///  added extra fields.......
        /// </summary>

        public decimal? Price { get; set; }   
        public bool IsReservationRequired { get; set; }

        public int Capacity { get; set; }   

        public string? Location { get; set; } 

        public string? ContactPerson { get; set; }  

        public string? ContactNumber { get; set; }  

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }



    }
}
