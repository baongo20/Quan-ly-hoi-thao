using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An.Areas.Host.Controllers
{
    public class HomeController : Controller
    {
        // GET: Host/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}