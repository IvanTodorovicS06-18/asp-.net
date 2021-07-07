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
    public class BooksController : Controller
    {

        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
     
      
      
        [Authorize(Roles =RollName.Administrator)]
        public ActionResult New()
        {
            var publishers = _context.Publishers.ToList();

            var viewModel = new bookFormViewModel
            {
                Book = new Book(),
                Publishers = publishers
            };

            return View("BookInsert", viewModel);

        }

        [Authorize(Roles = RollName.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new bookFormViewModel
                {
                    Book = book,
                    Publishers = _context.Publishers.ToList()
                };
                return View("BookInsert", viewModel);
            }
            // insert ako vrednosti nisu prosledjene dodaje novi unos | update ako jesu tj ako se kliknte edit prosledjuju se vrednosti i vrsi se update 
            if (book.id == 0)
            {
                _context.Books.Add(book);
            }

            else
            {
                var Bookup = _context.Books.Single(b => b.id == book.id);
                Bookup.title = book.title;
                Bookup.author = book.author;
                Bookup.genre = book.genre;
                Bookup.pages = book.pages;
                Bookup.ISBN = book.ISBN;
                Bookup.language = book.language;
                Bookup.price = book.price;
                Bookup.publisherId = book.publisherId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var Books = _context.Books.Include(g => g.Publisher).ToList();

            if (User.IsInRole(RollName.Administrator))
            {
                return View("Index",Books);
            }
            else
            {
                return View("IndexReadOnly", Books);
            }
           
        }

        [Authorize(Roles = RollName.Administrator)]
        public ActionResult BookDetails(int id)
        {
            var Books = _context.Books.Include(g => g.Publisher).SingleOrDefault(c => c.id == id);

            if (Books == null)
            {
                return HttpNotFound();
            }

            return View(Books);
        }
        [Authorize(Roles = RollName.Administrator)]
        public ActionResult Delete(Book Book)
        {
            var bookdel = _context.Books.SingleOrDefault(c => c.id == Book.id);
            _context.Books.Remove(bookdel);
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
        [Authorize(Roles = RollName.Administrator)]
        public ActionResult Edit(int id)
        {
            var Bookup = _context.Books.SingleOrDefault(c => c.id == id);

            if (Bookup == null)
                return HttpNotFound();

            var viewModel = new bookFormViewModel
            {
                Book = Bookup,
                Publishers = _context.Publishers.ToList()
            };

            return View("BookInsert", viewModel);
        }
    }
}