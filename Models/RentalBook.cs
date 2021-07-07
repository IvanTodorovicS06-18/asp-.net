using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rvas_ispit_projekat.Models
{
    public class RentalBook
    {
        [Required]
        [Key]
        public int id { get; set; }

        public  virtual User User { get; set; }
        [Required]
        public int userID { get; set; }
 

        public virtual Book Book { get; set; }
        [Required]
        public int bookID { get; set; }

        [Required]
        [RentalDate]
        [Display(Name ="Date rented")]
        public DateTime dateRented { get; set; } 
        public DateTime? dateReturned { get; set; }

    }
}