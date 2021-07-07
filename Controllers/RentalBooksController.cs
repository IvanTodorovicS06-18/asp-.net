using Rvas_ispit_projekat.Models;
using Rvas_ispit_projekat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;   
namespace Rvas_ispit_projekat.Controllers
{
    public class RentalBooksController : Controller
    {
        private ApplicationDbContext _context;

        public RentalBooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = "Administrator,User")]
        public ActionResult New()
        {
            var User = _context.Users.ToList();
            var Book = _context.Books.ToList();

            var ViewModel = new RentalsViewModel
            {
                rentalBook = new RentalBook(),
                users = User,
                books = Book
            };
            return View("Rental",ViewModel);
        }
        // GET: Rentals
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Index()
        {
            var rentals = _context.RentalBooks.Include(r => r.Book.Publisher).Include(r => r.User).ToList();
            return View(rentals);
            
        }
        [Authorize(Roles = "Administrator,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RentalBook rentalBook)
        {
            var bookRental = _context.Books.SingleOrDefault(b => b.id == rentalBook.bookID);
            var userRental = _context.Users.SingleOrDefault(u => u.id == rentalBook.userID);

            if (!ModelState.IsValid)
            {
                var User = _context.Users.ToList();
                var Book = _context.Books.ToList();
                var viewModel = new RentalsViewModel
                {
                    books = Book,
                    users = User,
                    rentalBook = new RentalBook(),
                   
                };
                return View("Rental", viewModel);
            }
            // insert ako vrednosti nisu prosledjene dodaje novi unos | update ako jesu tj ako se kliknte edit prosledjuju se vrednosti i vrsi se update 
            if (rentalBook.id == 0)
            {
                _context.RentalBooks.Add(rentalBook);
                bookRental.RentalBooks.Add(rentalBook);
                userRental.RentalBooks.Add(rentalBook);
            }
            else
            {
            var rentalUp = _context.RentalBooks.SingleOrDefault(r => r.id == rentalBook.id);
                rentalUp.dateRented = rentalBook.dateRented;
            rentalUp.bookID = rentalBook.bookID;
            rentalUp.userID = rentalBook.userID;
            }
             

            _context.SaveChanges();
            return RedirectToAction("index","RentalBooks");
        }
        [Authorize(Roles = "Administrator,User")]
        public ActionResult RentalDetails(int id)
        {
            var rental = _context.RentalBooks.Include(r => r.Book.Publisher).Include(r => r.User).SingleOrDefault(r => r.id == id);
            if(rental == null)
            {
                return HttpNotFound();
            }

            return View(rental);
        }
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Edit(int id)
        {
            var rental = _context.RentalBooks.SingleOrDefault(r => r.id == id);
            if(rental == null)
            {
                return HttpNotFound();
            }
            var viewModel = new RentalsViewModel
            {
                rentalBook = rental,
                books = _context.Books.ToList(),
                users = _context.Users.ToList()

            };

            return View("Rental",viewModel);
        }
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Delete(RentalBook rentalBook)
        {
            var rental = _context.RentalBooks.SingleOrDefault(r => r.id == rentalBook.id);
            _context.RentalBooks.Remove(rental);
            _context.SaveChanges();
            return RedirectToAction("index","RentalBooks");
        }

        [Authorize(Roles = "Administrator,User")]
        public ActionResult ReturnBook(int id)
        {
            var rental = _context.RentalBooks.SingleOrDefault(r => r.id == id);
            rental.dateReturned = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("index", "RentalBooks");
        }


    }
}