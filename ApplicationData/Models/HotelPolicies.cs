using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelPolicies
    {
        [Key]
        public Guid PolicyId { get; set; }
        public string? HotelId { get; set; }
        public string? PolicyType { get; set; }
        public string? Description { get; set; }
    }
}
