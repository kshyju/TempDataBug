using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TempData.Models;

namespace TempData.Controllers
{
    public class IndexViewModel
    {
        public string Code { set; get; }
       public bool ShouldSetTempData { set; get; }
    }
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            model.Code = "This was set in HttpPost at" + DateTime.Now;
            if (model.ShouldSetTempData)
            {
                TempData["MyModel"] = model;
            }
            return RedirectToAction("About","Home");
        }

        public IActionResult About()
        {
            var m = TempData["MyModel"] as IndexViewModel;
            ViewBag.Message = m?.Code ?? " There was nothing in TempData. Try with the checkbox checked";
            return View();
        }
    }
}
