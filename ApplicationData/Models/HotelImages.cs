using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Models
{
    public class HotelImages
    {
        [Key]
        public int Id { get; set; }
        public Guid ImageId { get; set; }
        public string HotelId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public bool? IsPrimary { get; set; }
    }
}
