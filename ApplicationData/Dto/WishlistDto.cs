using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class WishlistDto
    {
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}