using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Pustok.Areas.Admin.Helpers;
using MVC_Pustok.Areas.Admin.ViewModels;
using MVC_Pustok.Data;
using MVC_Pustok.Models;

namespace MVC_Pustok.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BookController : Controller

    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public BookController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env; 
        }
        public IActionResult Index(int page = 1)
        {
            var query = _context.Books.Include(x => x.Author).Include(x => x.Genre).Include(x => x.BookImages.Where(x => x.PosterStatus == true)).OrderByDescending(x => x.Id);

            return View(PaginatedList<Book>.Create(query, page, 2));
        }

        public IActionResult Delete(int id)
        {
            Book existBook = _context.Books.Find(id);
            if (existBook == null) return NotFound();

            _context.Books.Remove(existBook);
            _context.SaveChanges();

            return Ok();
        }


        public IActionResult Create()
        {
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (book.PosterFile == null) ModelState.AddModelError("PosterFile", "Poster file is required !");
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = _context.Genres.ToList();
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Tags = _context.Tags.ToList();

                return View(book);
            }

            if (!_context.Authors.Any(x => x.Id == book.AuthorId))
                return RedirectToAction("Notfound", "Error");

            if (!_context.Genres.Any(x => x.Id == book.GenreId))
                return RedirectToAction("Notfound", "Error");


            foreach (var tagId in book.TagIds)
            {
                if(!_context.Tags.Any(x=> x.Id == tagId)) return RedirectToAction("notfound","error");

                Booktags booktags = new Booktags()
                {
                    TagId = tagId,
                };
                book.BookTags.Add(booktags);
            }


            BookImgs poster = new BookImgs()
            {
                Name = FileManager.Save(book.PosterFile, _env.WebRootPath, "uploads/book"),
                PosterStatus = true
            };
            book.BookImages.Add(poster);

            foreach (var imgFile in book.ImageFiles)
            {
                BookImgs bookImg = new BookImgs
                {
                    Name = FileManager.Save(imgFile, _env.WebRootPath, "uploads/book"),
                    PosterStatus = null,
                };
                book.BookImages.Add(bookImg);
            }
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Book book = _context.Books.Include(x => x.BookTags).Include(x => x.BookImages).FirstOrDefault(x => x.Id == id);

            if (book == null) return RedirectToAction("notfound", "error");

            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            book.TagIds = book.BookTags.Select(x => x.TagId).ToList();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            Book? existBook = _context.Books.Find(book.Id);


            if (existBook == null) return RedirectToAction("notfound", "error");

            if (book.AuthorId != existBook.AuthorId && !_context.Authors.Any(x => x.Id == book.AuthorId))
                return RedirectToAction("notfound", "error");

            if (book.GenreId != existBook.GenreId && !_context.Genres.Any(x => x.Id == book.GenreId))
                return RedirectToAction("notfound", "error");

            existBook.Name = book.Name;
            existBook.Desc = book.Desc;
            existBook.SalePrice = book.SalePrice;
            existBook.CostPrice = book.CostPrice;
            existBook.DiscountPerc = book.DiscountPerc;
            existBook.IsNew = book.IsNew;
            existBook.IsFeatured = book.IsFeatured;
            existBook.StockStatus = book.StockStatus;

            existBook.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return RedirectToAction("index");
        }



    }
}
