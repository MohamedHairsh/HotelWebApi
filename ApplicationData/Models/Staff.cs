using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{


    
    public class Staff
        {
        [Key]
        public Guid StaffId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Required]

        public string StaffImage { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }





    }
}
