using ApaYah.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApaYah.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext c)
        {
            _context = c;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Username,Password")] UserLogin data)
        {
            var user = _context.User
                .Where(x => x.Username == data.Username
                    && x.Password == data.Password)
                .Include(x => x.Role)
                .FirstOrDefault();

            if (user != null)
            {
                var claims = new List<Claim> { 
                    new Claim("username", user.Username),
                    new Claim("role", user.Role.Name)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(
                    new ClaimsIdentity(claims, "Cookies", "username", "role")
                    ));

                if (user.Role.Id == 1)
                {
                    return Redirect("/admin/home");
                }
                else if (user.Role.Id == 2)
                {
                    return Redirect("/user/home");
                }

                return Redirect("/home");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
