using BussinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace WebDesign.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin,Uye")]
    public class BlogsController : Controller
    {
        private IBlogService service;
        private ICategoriesService categoriesService;
        public BlogsController(IBlogService service,ICategoriesService categoriesService) 
        {
            this.categoriesService = categoriesService;
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAll());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Categories = categoriesService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Insert(TBLBlog data, IFormFile file)
        {
            if (file is not null)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension == ".jpg" || extension == ".jpeg")
                {
                    string FolderName = Guid.NewGuid() + extension;
                    string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{FolderName}");
                    using var stream = new FileStream(FolderPath, FileMode.Create);
                    file.CopyToAsync(stream);
                    data.Images = FolderName;
                    ViewBag.message = service.Insert(data);
                }
                else
                {
                    ViewBag.error = "jpeg veya jpg uzantılı dosya seçiniz";
                }
            }
            else
            {
                ViewBag.error = "Lütfen Bir Dosya Seçiniz";
            }
            ViewBag.Categories = categoriesService.GetAll();
            return View();
        }

        [HttpGet]
        [Route("/Admin/Blog/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            ViewBag.Categories = categoriesService.GetAll();
            return View(service.GetById(Id));
        }

        [HttpPost]
        [Route("/Admin/Blog/Update/{Id}")]
        public IActionResult Update(TBLBlog data, IFormFile file,int Id)
        {
            var Finded = service.GetById(Id);
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    string FolderName = Guid.NewGuid() + extension;
                    string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{FolderName}");
                    using var stream = new FileStream(FolderPath, FileMode.Create);
                    file.CopyToAsync(stream);
                    Finded.Images = FolderName;
                }
            }
            Finded.BlogName = data.BlogName;
            Finded.Explanation = data.Explanation;
            Finded.Author = data.Author;
            Finded.Title = data.Title;
            ViewBag.message = service.Update(Finded);
            ViewBag.Categories = categoriesService.GetAll();
            return View(service.GetById(Id));
        }

        [HttpGet]
        [Route("/Admin/Blog/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(Id);
            return Redirect("/Admin/Blogs");
        }
    }
}
