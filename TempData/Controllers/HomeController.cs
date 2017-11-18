using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TempData.Models;

namespace TempData.Controllers
{
    [Serializable]
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
                var s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                TempData["MyModel"] = s;

                Dictionary<string, string> d = new Dictionary<string, string>
                {
                    ["Name"] = "Shyju",
                    ["Age"] = "12"
                };
                TempData["MyModelDict"] = d;
            }
            return RedirectToAction("About", "Home");
        }

        public IActionResult About()
        {
            string msg = string.Empty;
            if (TempData["MyModel"] is string s)
            {
                var m = JsonConvert.DeserializeObject<IndexViewModel>(s);
                msg = m.Code;
            }
            else
            {
                msg = " There was nothing in TempData. Try with the checkbox checked";

            }

            if (TempData["MyModelDict"] is Dictionary<string, string> dict)
            {
                msg += "Name : " + dict["Name"];
                msg += "Age : " + dict["Age"];
            }
            ViewBag.Message = msg;
            return View();
        }
    }
}
