using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.Admin.Controllers
{
    public class UnauthorizedController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
