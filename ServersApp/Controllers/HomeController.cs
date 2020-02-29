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
        private readonly IVirtualServersHandler virtualServersHandler;

        public HomeController(IVirtualServersModelBuilder virtualServersModelBuilder, IVirtualServersHandler virtualServersHandler)
        {
            this.virtualServersModelBuilder = virtualServersModelBuilder;
            this.virtualServersHandler = virtualServersHandler;
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

        [HttpPost]
        public ActionResult Create()
        {
            virtualServersHandler.Create();
            return List();
        }

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            if (ids != null && ids.Any())
            {
                virtualServersHandler.Delete(ids);
            }

            return List();
        }
    }
}