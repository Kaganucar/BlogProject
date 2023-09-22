using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExitController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
    }
}
