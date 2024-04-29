using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Pustok.Areas.Admin.ViewModels;
using MVC_Pustok.Data;
using MVC_Pustok.Models;

namespace MVC_Pustok.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _context.Books.Include(x => x.Author).Include(x => x.Genre);
            return View(PaginatedList<Book>.Create(query, page, 2));
        }
    }
}
