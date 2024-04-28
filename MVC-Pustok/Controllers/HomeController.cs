using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Pustok.Data;
using MVC_Pustok.Models;
using MVC_Pustok.ViewModels;
using System.Diagnostics;

namespace MVC_Pustok.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                Features = _context.Features.ToList(),
                Sliders = _context.Sliders.OrderBy(x=> x.Order).ToList(),
                NewBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.PosterStatus != null)).Where(x => x.IsNew).Take(10).ToList(),
                FeaturedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.PosterStatus != null)).Where(x => x.IsFeatured).Take(10).ToList(),
                DiscountedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.PosterStatus != null)).Where(x => x.DiscountPerc > 0).OrderByDescending(x => x.DiscountPerc).Take(10).ToList(),
            };

            return View(vm);
        }

    }
}
