using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Pustok.Areas.Admin.Helpers;
using MVC_Pustok.Areas.Admin.ViewModels;
using MVC_Pustok.Data;
using MVC_Pustok.Models;

namespace MVC_Pustok.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _context.Sliders.OrderByDescending(x => x.Id);
            return View(PaginatedList<Slider>.Create(query, page, 2));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider.ImageFile == null) ModelState.AddModelError("ImageFile", "ImageFile is required!");

            if (!ModelState.IsValid) return View();
            slider.Image = FileManager.Save(slider.ImageFile, _env.WebRootPath, "uploads/slider");

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null) return RedirectToAction("NotFound", "Error");

            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid) return View(slider);

            Slider existSlider = _context.Sliders.Find(slider.Id);
            if (existSlider == null) return RedirectToAction("Error", "NotFound");

            string deletedFile = null;
            if (slider.ImageFile != null)
            {
                deletedFile = existSlider.Image;
                existSlider.Image = FileManager.Save(slider.ImageFile, _env.WebRootPath, "uploads/slider");
            }

            existSlider.Title1 = slider.Title1;
            existSlider.Title2 = slider.Title2;
            existSlider.Desc = slider.Desc;
            existSlider.BtnURL = slider.BtnURL;
            existSlider.BtnText = slider.BtnText;
            existSlider.Order = slider.Order;

            if (deletedFile != null)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/slider", deletedFile);
            }

            _context.SaveChanges();
            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {
            Slider existSlider = _context.Sliders.Find(id);
            if (existSlider == null) return NotFound();

            _context.Sliders.Remove(existSlider);
            _context.SaveChanges();

            FileManager.Delete(_env.WebRootPath, "uploads/slider", existSlider.Image);
            return Ok();
        }

      


    }
}
