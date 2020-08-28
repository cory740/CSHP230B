using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEby_Website.Data;
using CEby_Website.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore.Storage;

namespace CEby_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassRepository classRepository;
        private readonly IUserRepository userRepository;
        private readonly IEnrollClassRepository enrollClassRepository;

        public HomeController(IClassRepository classRepository, IUserRepository userRepository, IEnrollClassRepository enrollClassRepository)
        {
            this.classRepository = classRepository;
            this.userRepository = userRepository;
            this.enrollClassRepository = enrollClassRepository;
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

        public ActionResult Classes()
        {
            var classes = classRepository.Classes
                .Select(t => new CEby_Website.Models.ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                .ToArray();

            var model = new IndexModel { GetClasses = classes };
            return View(model);
        }

        [Authorize]
        public ActionResult StudentClasses(int userId)
        {
            var database = new ClassViewModel();
            var sessionUser = (CEby_Website.Models.UserModel)Session["User"];
            var user = DatabaseAccessor.Instance.User.First(t => t.UserId == sessionUser.Id);
            return View(user.UserClass);
        }

        [Authorize]
        public ActionResult EnrollInClass()
        {

            var classOptions = new ClassViewModel();
            var model = new EnrollClassModel()
            {
                ClassList = classOptions.Classes

                //classRepository.Classes
                //.Select(t => new ClassModel { ClassId = t.ClassId, ClassName = t.ClassName, ClassDescription = t.ClassDescription, ClassPrice = t.ClassPrice })
                //.ToArray();
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EnrollAClass(EnrollClassModel model)
        {
            var database = new ClassViewModel();
            var sessionUser = (CEby_Website.Models.UserModel)Session["User"];
            //var item = enrollClassRepository.GetEnrolledClasses(model);
            var user = DatabaseAccessor.Instance.User.First(t => t.UserId == sessionUser.Id);
            var newClass = DatabaseAccessor.Instance.Class.First(t => t.ClassId == model.ClassId);

            user.UserClass.Add(newClass);

            database.SaveChanges();

            return Redirect("~/Home/StudentClasses");
        }

        []

       
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                userRepository.Register(registerModel.UserName, registerModel.Password);

                return Redirect("~/");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.Login(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Your Username and/or Password do not match.");
                }
                else
                {
                    Session["User"] = new CEby_Website.UserModel
                    {
                        Id = user.Id,
                        Name = user.Name
                    };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }
            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");

        }


    }
}