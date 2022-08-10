using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Book
    {
        [Key]
        [Required(ErrorMessage="BookId is Required")]
        public int BookId { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage="Book Name is Required")]
        [Column(TypeName="varchar(100)")]
        public string BookName { get; set; }
        [Column(TypeName ="varchar(200)")]
        public string Detail { get; set; }
        [Required(ErrorMessage ="Author is Requird")]
        [Column(TypeName ="varchar(100)")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Publication is Requird")]
        public int PubId { get; set; }
        [ForeignKey("PubId")]
        public Publication Publications { get; set; }
        [Required(ErrorMessage = "Branch is Requird")]
        
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branchs { get; set; }
        [Required(ErrorMessage ="Price is Required")]
        [Column(TypeName="decimal(5,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Quantity is Required")]
        public int Quantity { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string BookPhoto { get; set; }
        public bool IsActive { get; set; }
        public int Rent { get; set; }
        public int Available { get; set; }
       
    }
}
