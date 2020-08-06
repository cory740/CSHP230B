using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEby_Website.Data;

namespace CEby_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassRepository classRepository;
        public HomeController(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Classes(int classid)
        {
            var classes = classRepository
                .ForClass
                .Select(t =>
                new CEby_Website.ClassModel
                {
                    ClassId = t.ClassId,
                    ClassName = t.ClassName,
                    ClassDescription = t.ClassDescription,
                    ClassPrice = t.ClassPrice
                }).ToArray();

            return View(classes);
        }

 
    }
}