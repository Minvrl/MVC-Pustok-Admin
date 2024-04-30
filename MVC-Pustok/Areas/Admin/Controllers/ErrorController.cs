using Microsoft.AspNetCore.Mvc;

namespace MVC_Pustok.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
