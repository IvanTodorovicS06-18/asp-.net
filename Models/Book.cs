using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rvas_ispit_projekat.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Please enter the book title"),MaxLength(50)]
        public string title { get; set; }
    
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Author"), MaxLength(50)]
        public string author { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the book genre"), MaxLength(30)]
        public string genre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the number of pages")]
        [BookPages]
        public int pages { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the book ISBN"), MaxLength(18)]
        public string ISBN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the book language"), MaxLength(20)]
        public string language { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the book price")]
        [BookPrice]
        public decimal price { get; set; }
        public Publisher Publisher { get; set; }
        [Required]
        [ForeignKey("Publisher")]
        public int publisherId { get; set; }
        public virtual ICollection<RentalBook> RentalBooks { get; set; }
      
    }

        
}