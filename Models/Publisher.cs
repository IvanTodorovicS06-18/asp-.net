using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rvas_ispit_projekat.Models
{
    public class Publisher
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required]
        public string publisherName { get; set; }

        [Required]
        public string phone { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}