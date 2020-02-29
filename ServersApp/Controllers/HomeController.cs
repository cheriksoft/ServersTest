using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServersApp.Models;

namespace ServersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVirtualServersModelBuilder virtualServersModelBuilder;

        public HomeController(IVirtualServersModelBuilder virtualServersModelBuilder)
        {
            this.virtualServersModelBuilder = virtualServersModelBuilder;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            var model = virtualServersModelBuilder.Build();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}