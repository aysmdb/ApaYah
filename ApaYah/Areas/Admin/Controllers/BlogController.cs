using ApaYah.Models;
using ApaYah.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApaYah.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly FileService _file;

        public BlogController(AppDbContext c, FileService f)
        {
            _context = c;
            _file = f;
        }

        public IActionResult Index()
        {
            var blog = _context.Blog.ToList();

            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Content,Author,IsPublished,Image")] Blog blog,
            IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                blog.CreatedDate = DateTime.Now;
                blog.Image = await _file.SaveFile(Image);
                _context.Add(blog);
                _context.SaveChanges();

                return Redirect("/admin/blog");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = _context.Blog.Find(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id,Title,Content,Author,IsPublished")] Blog blog)
        {
            var data = _context.Blog.Find(blog.Id);

            if (data == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                data.Title = blog.Title;
                data.Content = blog.Content;
                data.Author = blog.Author;
                data.IsPublished = blog.IsPublished;

                _context.Update(data);
                _context.SaveChanges();

                return Redirect("/admin/blog");
            }

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = _context.Blog.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Remove(data);
            _context.SaveChanges();

            return Redirect("/admin/blog");
        }
    }
}
