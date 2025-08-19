using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelReview
    {
        [Key]
        public Guid ReviewId { get; set; }
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public string ReviewerName { get; set; } = string.Empty;
        public string ReviewerCountry { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string ReviewTitle { get; set; } = string.Empty;
        public string ReviewBody { get; set; } = string.Empty;
        public DateTime SubmittedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}