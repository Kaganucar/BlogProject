using BussinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebDesign.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private IUserService service;
        public LoginController(IUserService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email, string Password)
        {
            var Finded = service.GetAll(false).Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();

            if(Finded != null)
            {
                var claims = new List<Claim>
                {
                    // Email == kagan@gmail.com
                    // Şifre == 123
                    new Claim(ClaimTypes.Name,Finded.Email),
                    new Claim(ClaimTypes.Role,Finded.Roles)
                };
                var claimsIdentity = new ClaimsIdentity(claims,"Cookies");

                var claimsprincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsprincipal);
                return Redirect("/Admin/Categories");
            }
            else
            {
                ViewBag.message = "Email veya Şifre Hatalı";
            }
            return View();
        }
    }
}
