using ApaYah.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApaYah.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext c)
        {
            _context = c;
        }

        public IActionResult Index()
        {
            var data = _context.Blog.Where(x => x.IsPublished).ToList();

            return View(data);
        }
    }
}
