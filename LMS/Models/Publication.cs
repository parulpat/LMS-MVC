using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Publication
    {
        [Key]
        [Required(ErrorMessage = "PubId Is Required")]
        public int PubId { get; set; }
        [Required(ErrorMessage = "Publication Name is Required")]
        [StringLength(100)]
        [Column(TypeName="varchar(200)")]
        public string PublicationName { get; set; }
        public bool IsActive { get; set; }
    }
}
