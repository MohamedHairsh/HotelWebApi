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



        [Required, MaxLength(20)]
    public string EmployeeCode { get; set; } = string.Empty; 

    [MaxLength(100)]
    public string Department { get; set; } = string.Empty;   

    [MaxLength(100)]
    public string Designation { get; set; } = string.Empty;   

    [MaxLength(100)]
    public string Qualification { get; set; } = string.Empty; 

    [MaxLength(20)]
    public string MaritalStatus { get; set; } = string.Empty; 

    [MaxLength(50)]
    public string Nationality { get; set; } = string.Empty;

    [MaxLength(5)]
    public string BloodGroup { get; set; } = string.Empty;

    [MaxLength(100)]
    public string EmergencyContactName { get; set; } = string.Empty;

    [MaxLength(15)]
    public string EmergencyContactNumber { get; set; } = string.Empty;

    [MaxLength(50)]
    public string WorkType { get; set; } = string.Empty;      

    [MaxLength(20)]
    public string Status { get; set; } = "Active";          

    public decimal? Salary { get; set; }                   

    public Guid? ReportingManagerId { get; set; }            

    [MaxLength(500)]
    public string Remarks { get; set; } = string.Empty;

        [Required]

        public string StaffImage { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }





    }
}
