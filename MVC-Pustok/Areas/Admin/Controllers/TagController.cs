using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Pustok.Areas.Admin.ViewModels;
using MVC_Pustok.Data;
using MVC_Pustok.Models;

namespace MVC_Pustok.Areas.Admin.Controllers
{
    [Area("admin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Tags.Include(x => x.Tags);

            return View(PaginatedList<Tag>.Create(query,page,2));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag) 
        { 
            _context.Tags.Add(tag);
            _context.SaveChanges();

            return RedirectToAction("Index");   
        }
    }
}
