using Microsoft.AspNetCore.Mvc;

namespace TempData.Controllers
{
   
    public class ModelBinderTestViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Model { set; get; }
    }
    public class ModelBinderTestController : Controller
    {
        public IActionResult Index()
        {
            return View(new ModelBinderTestViewModel { Name = "Shyju", Model = "Honda"});
        }
       
        public IActionResult Create(ModelBinderTestViewModel model)
        {
            return View("PostedData",model);
        }
        public IActionResult Create2(ModelBinderTestViewModel model)
        {
            return Json(model);
        }
    }
}