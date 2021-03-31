using mhcapstone.Areas.Data;
using mhcapstone.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mhcapstone.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationDbContext CONTEXT;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            CONTEXT = context;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult ListUsers()
        {
            var query = _context.User.ToList();

            return View(query);
        }

        public ActionResult DeleteUsers(string id)
        {
            var user = _context.User.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult DeleteUsers(User appuser)
        {
            var user = _context.User.Where(u => u.Id == appuser.Id).FirstOrDefault();
            _context.User.Remove(user);
            _context.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("ListUsers");
        }

        public ActionResult EditUsers(string id)
        {
            var context = CONTEXT;
            var user = context.User.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUsers(User appuser)
        {
            var user = _context.User.Where(u => u.Id == appuser.Id).FirstOrDefault();
            user.Email = appuser.Email;
            user.FirstName = appuser.FirstName;
            user.LastName = appuser.LastName;
            user.Active = appuser.Active;
            user.BirthDate = appuser.BirthDate;
            _context.SaveChanges();
            return RedirectToAction("ListUsers");
        }

        // GET: Roles
        public ActionResult ListRoles()
        {
            var Roles = _context.Roles.ToList();
            return View(Roles);
        }
    }


}