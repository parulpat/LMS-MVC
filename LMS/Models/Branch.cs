using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Branch
    {
        [Required(ErrorMessage="BranchId is Required")]
        public int BranchId { get; set; }
        [Required(ErrorMessage = "BranchName is Required")]
        [Column(TypeName="varchar(100)")]
        public string BranchName  { get; set; }
        public bool IsActive { get; set; }
    }
}
