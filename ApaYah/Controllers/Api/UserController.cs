using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApaYah.Models;
using ApaYah.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace ApaYah.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly EmailService _email;

        public UserController(AppDbContext c, EmailService e)
        {
            _context = c;
            _email = e;
        }

        [HttpGet]
        [Route("listuser")]
        public IActionResult GetListUser()
        {
            var user = _context.User.ToList();

            return Ok(user);
        }

        [HttpGet]
        [Route("oneuser/{id}")]
        public IActionResult GetOneUser([FromQuery] int id)
        {
            var user = _context.User.Find(id);

            return Ok(user);
        }

        [HttpPost]
        [Route("createuser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpPut]
        [Route("updateuser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("deleteuser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.User.Find(id);

            _context.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        [Route("sendemail")]
        public IActionResult SendEmail()
        {
            _email.Send("for_you@gmail.com","from_me@gmail.com",
                "Email Kedua",
                "<b>ini isi</b>");

            return NoContent();
        }
    }
}
