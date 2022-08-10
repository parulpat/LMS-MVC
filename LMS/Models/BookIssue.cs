using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class BoookIssue
    {
        [Key]
        [Required(ErrorMessage ="IssueId is required")]
        public int IssueId { get; set; }
        [Required(ErrorMessage = "Days is required")]
        public int Days { get; set; }
        [Required(ErrorMessage = "Publication is required")]
       
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public  Book Books { get; set; }

        [Required(ErrorMessage = "Student is required")]
        public int StudentId { get; set; }
        //[ForeignKey("StudentId")]
       public Student Students { get; set; }
        public bool IsActive { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string PanaltyStatus { get; set; }
    }
}
