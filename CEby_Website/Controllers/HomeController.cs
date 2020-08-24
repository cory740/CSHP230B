using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEby_Website.Data;
using CEby_Website.Models;

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

        public ActionResult Classes(int id)
        {

            var classes = classRepository
                    .ForClass(id)
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

        [Authorize]
        public ActionResult EnrollAClass(int id)
        {
            var user = (CEby_Website.Models.UserModel)Session["User"];
            var item = enrollClassRepository.Add(user.Id, id);
            //var item = shoppingCartManager.Add(user.Id, id, 1);
            //var items = shoppingCartManager.GetAll(user.Id)
            var items = enrollClassRepository.GetAll(user.Id)
                .Select(t => new CEby_Website.Models.EnrollClassModel
                {
                    UserId = t.UserId,
                    ClassId = t.ClassId
                })
                .ToArray();
            return View(items);
        }

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