using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CEby_CoreWebsite.Models;

namespace CEby_CoreWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassRepository classRepository;
        public HomeController(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Classes()
        {
            var classes = classRepository.Classes
                .Select(t => new CEby_CoreWebsite.Models.ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                .ToArray();

            var model = new IndexModel { GetClasses = classes };
            return View(model);
        }
    }
}
