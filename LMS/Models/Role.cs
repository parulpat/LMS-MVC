using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Column(TypeName = "varchar(20)")]
      //  [StringLength(20,MinimumLength =10)]
        public string RoleName { get; set; }
    }
}
