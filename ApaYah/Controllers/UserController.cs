using ApaYah.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApaYah.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext c)
        {
            _context = c;
        }

        public IActionResult Index()
        {
            var data = _context.User.ToList();

            return View(data);
        }

        public IActionResult Register()
        {
            var role = _context.Roles.ToList();

            return View(role);
        }

        [HttpPost]
        public IActionResult Register([Bind("Username,Name,Password,Role")] 
            UserForm data)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Username = data.Username, 
                    Password = data.Password,
                    Name = data.Name
                };

                var role = _context.Roles
                    .FirstOrDefault(x => x.Id == data.Role);

                if (role != null)
                {
                    user.Role = role;
                }

                _context.Add(user);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = _context.User.Find(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id,Username,Name,Password,Role")]
            User data)
        {
            if (ModelState.IsValid)
            {
                var finduser = _context.User.Find(data.Id);

                if (finduser == null)
                {
                    return NotFound();
                }

                finduser.Username = data.Username;
                finduser.Name = data.Name;
                finduser.Password = data.Password;

                _context.Update(finduser);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _context.User.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Remove(data);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
