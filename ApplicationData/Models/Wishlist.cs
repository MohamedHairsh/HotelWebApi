using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class Wishlist
    {
        [Key]
        public Guid WishlistId { get; set; }
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }

      
        


    }
}