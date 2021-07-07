using Rvas_ispit_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rvas_ispit_projekat.ViewModel
{
    public class bookFormViewModel
    {
        public  Book Book { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}