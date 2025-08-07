using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelReviewCategory
    {
        [Key]
        public Guid HotelReviewCategoryId { get; set; }
        public Guid ReviewId { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}