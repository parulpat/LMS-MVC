using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Penalty
    {
        [Key]
        public int PenaltyId { get; set; }
        public string Author { get; set; }
        public string PublicationName { get; set; }
        public string BranchName { get; set; }
        public decimal Price { get; set; }
        public string StudentName { get; set; }
        public int Day { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; }
        public decimal PenaltyAmount  { get; set; }
        public string Reason { get; set; }
        public string BookName { get; set; }
        public string BookPhotoPath { get; set; }
    }
}
