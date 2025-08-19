using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class MasterBed
    {
        [Key]
        public Guid BedID { get; set; }
        public string BedType { get; set; }
    }
}
