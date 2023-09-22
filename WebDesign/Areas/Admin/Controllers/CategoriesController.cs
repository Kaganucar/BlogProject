using BussinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles = "Admin,Uye")]
    public class CategoriesController : Controller
    {
        private ICategoriesService service;

        public CategoriesController(ICategoriesService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(TBLCategories data)
        {
            ViewBag.message = service.Insert(data);
            return View();
        }

        [HttpGet]
        [Route("/Admin/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(Id));
        }

        [HttpPost]
        [Route("/Admin/Update/{Id}")]
        public IActionResult Update(TBLCategories data, int Id)
        {
            var Finded = service.GetById(Id);
            Finded.CategoryName = data.CategoryName;
            ViewBag.message = service.Update(Finded);
            return View(service.GetById(Id));
        }

        [HttpGet]
        [Route("/Admin/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(Id);
            return Redirect("/Admin/Categories");
        }
    }
}
