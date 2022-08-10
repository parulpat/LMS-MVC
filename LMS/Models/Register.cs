using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Register
    {
        [Key]
        [Required(ErrorMessage = "RegId is Required")]
        public int RegId { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Column(TypeName = "varchar(200)")]
        //[DataType(DataType.Password)]
        //[Compare("Password",ErrorMessage ="Your Password did not matched")]
        //[Required(ErrorMessage = "ConfirmPassword is Required")]
        //public string ConfirmPassword { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "MobileNo is Required")]
        public string MobileNo { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Roles { get; set; }

    }
}
