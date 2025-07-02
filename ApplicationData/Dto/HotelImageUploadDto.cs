using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelImageInsertDto
    {
        public string HotelId { get; set; }

        public IFormFile[] ImageFile { get; set; }

        public string? Description { get; set; }

        public bool? IsPrimary { get; set; }
    }

    public class HotelImageUpdateDto : HotelImageInsertDto
    {
        public int Id { get; set; }
      
    }
}
