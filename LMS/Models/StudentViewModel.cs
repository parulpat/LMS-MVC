using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "Student id is Required")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student Name is Required")]
       
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Branch Id is Required")]
        public int BranchId { get; set; }
       
        public Branch Branchs { get; set; }

        [Required(ErrorMessage = "Gender is required")]
       
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Mobile No. is required")]
        
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Address is required")]
      
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
       
        public string City { get; set; }
        [Required(ErrorMessage = "Pincode is required")]
       
        public string Pincode { get; set; }
       
        public string PhotoPath { get; set; }
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Email is required")]
       
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        
        public Role Roles { get; set; }
        public string UserId { get; set; }
    }
}
