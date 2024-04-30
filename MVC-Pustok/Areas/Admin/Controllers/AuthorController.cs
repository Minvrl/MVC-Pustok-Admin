using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Pustok.Areas.Admin.ViewModels;
using MVC_Pustok.Data;
using MVC_Pustok.Models;

namespace MVC_Pustok.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index(int page = 1)
        {
            var query = _context.Authors.Include(x => x.Books);

            return View(PaginatedList<Author>.Create(query,page,2));
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Author existAuthor = _context.Authors.Find(id);
            if (existAuthor == null) return NotFound();

            _context.Authors.Remove(existAuthor);
            _context.SaveChanges();

            return Ok();
        }


        public IActionResult Edit(int id)
        {
            Author author= _context.Authors.Find(id);

            if (author == null) return RedirectToAction("NotFound", "Error");

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            Author existAuthor = _context.Authors.Find(author.Id);

            if (existAuthor == null) return RedirectToAction("NotFound", "Error");

            existAuthor.Fullname = author.Fullname;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
