using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class Facilities
    {

        [Key]

      

        public Guid FacilityId { get; set; }

        public string? FacilityName { get; set; }
        public string? Category { get; set; }
    }
}
