using Microsoft.AspNetCore.Mvc;

namespace MVC_Pustok.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
