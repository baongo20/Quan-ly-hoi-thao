using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;
using Do_An.ViewModels;

namespace Do_An.Areas.Host.Controllers
{
    public class ConferenceController : Controller
    {
        private DB_QLHTEntities db = new DB_QLHTEntities();
        // GET: Host/Conference
        public ActionResult Index()
        {
            return View();
        }

        // GET: Host/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Host/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CreateConferenceModel model)
        {
            return View();
        }
    }
}