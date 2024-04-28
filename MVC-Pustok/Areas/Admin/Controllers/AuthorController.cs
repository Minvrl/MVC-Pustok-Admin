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
    }
}
