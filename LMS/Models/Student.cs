using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Student
    {
        [Required(ErrorMessage="Student id is Required")]
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Student Name is Required")]
        [Column(TypeName="varchar(100)")]
        public string StudentName { get; set; }
        [Required(ErrorMessage ="Branch Id is Required")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branchs { get; set; }

        [Required(ErrorMessage ="Gender is required")]
        [Column(TypeName = "varchar(10)")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Mobile No. is required")]
        [Column(TypeName = "varchar(20)")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }
        [Required(ErrorMessage = "Pincode is required")]
        [Column(TypeName = "varchar(10)")]
        public string Pincode { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Roles { get; set; }

    }
}
