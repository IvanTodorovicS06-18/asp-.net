using Rvas_ispit_projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rvas_ispit_projekat.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Users
        [Authorize(Roles = RollName.Administrator)]
        public ActionResult New()
        {
            User user = new User();
            return View("User", user);
        }
        [Authorize(Roles = RollName.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {

                var usermodel = user;

                return View("User", usermodel);
            }
            // insert ako vrednosti nisu prosledjene dodaje novi unos | update ako jesu tj ako se kliknte edit prosledjuju se vrednosti i vrsi se update 
            if (user.id == 0)
            {
                _context.Users.Add(user);
            }

            else
            {   
                var UserUp = _context.Users.Single(c => c.id == user.id);
                UserUp.name = user.name;
                UserUp.lastname = user.lastname;
                UserUp.phone = user.phone;
                UserUp.email = user.email;
                UserUp.adress = user.adress;
              

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Users");



        }
        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            if (User.IsInRole(RollName.Administrator))
            {
                return View("Index", users);
            }
            else
            {
                return View("IndexReadOnly", users);
            }
          
        }

        [Authorize(Roles = RollName.Administrator)]
        public ActionResult UserDetails(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [Authorize(Roles = RollName.Administrator)]
        public ActionResult Delete(User user)
        {
            var UserDel = _context.Users.SingleOrDefault(c => c.id == user.id);
            _context.Users.Remove(UserDel);
            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        [Authorize(Roles = RollName.Administrator)]
        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.id == id);

            if (user == null)
            {
                return HttpNotFound();
            }


            return View("User", user);
        }

    }
}