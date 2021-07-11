using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApaYah.Controllers
{
    public class SekolahController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
