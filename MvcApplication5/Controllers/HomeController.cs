using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;
using Autofac.Features.Indexed;

namespace MvcApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IModelCar _carmodel;
        private readonly IModelUser _usermodel;

        public HomeController(IModelCar carmodel,IModelUser usermodel)
        {
            _carmodel = carmodel;
            _usermodel = usermodel;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "修改此模板以快速启动你的 ASP.NET MVC 应用程序。";
            var carname=_carmodel.GetCarName();
            var username = _usermodel.GetUserName();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的应用程序说明页。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你的联系方式页。";

            return View();
        }
    }
}
