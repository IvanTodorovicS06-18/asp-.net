using Rvas_ispit_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rvas_ispit_projekat.ViewModel
{
    public class RentalsViewModel
    {
        public List<Book> books { get; set; }
        public List<User> users { get; set; }

        public RentalBook rentalBook { get; set; }
    }
}