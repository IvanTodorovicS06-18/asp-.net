using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rvas_ispit_projekat.Models
{
    public class User
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the user name"), MaxLength(50)]
        public string name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the user last name"), MaxLength(50)]
        public string lastname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the user phone"), MaxLength(15)]
        public string phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the user email"), MaxLength(30)]
        public string email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the user adress"), MaxLength(50)]
        public string adress { get; set; }
        public virtual ICollection<RentalBook> RentalBooks {get; set;}
       




    }
}