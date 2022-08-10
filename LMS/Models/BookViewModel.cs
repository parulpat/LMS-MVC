using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class BookViewModel
    {
        [Key]
        [Required(ErrorMessage = "BookId is Required")]
        public int BookId { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Book Name is Required")]
        
        public string BookName { get; set; }
       
        public string Detail { get; set; }
        [Required(ErrorMessage = "Author is Requird")]
        
        public string Author { get; set; }
        [Required(ErrorMessage = "Publication is Requird")]
        public int PubId { get; set; }
        public Publication Publications { get; set; }
        [Required(ErrorMessage = "Branch is Requird")]

        public int BranchId { get; set; }
     
        public Branch Branchs { get; set; }
        [Required(ErrorMessage = "Price is Required")]
      
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }
        [NotMapped]
        public IFormFile BookPhoto { get; set; }
        public string BookPhotoPath { get; set; }
        public bool IsActive { get; set; }
        public int Rent { get; set; }
        public int Available { get; set; }
    }
}
