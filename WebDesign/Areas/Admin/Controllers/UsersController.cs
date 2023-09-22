using BussinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {

        private IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAll(true));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(TBLUser data)
        {
            ViewBag.message = service.Insert(data);
            return View();
        }

        [HttpGet]
        [Route("/Admin/User/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(Id));
        }

        [HttpPost]
        [Route("/Admin/User/Update/{Id}")]
        public IActionResult Update(TBLUser data, int Id)
        {
            var Finded = service.GetById(Id);
            Finded.Name = data.Name;
            Finded.Email = data.Email;
            Finded.Password = data.Password;
            Finded.Roles = data.Roles;
            ViewBag.message = service.Update(Finded);
            return View(service.GetById(Id));
        }

        [HttpGet]
        [Route("/Admin/User/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(Id);
            return Redirect("/Admin/Users");
        }
    }
}
