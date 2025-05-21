using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;

namespace Do_An.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private DB_QLHTEntities db = new DB_QLHTEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult LoadConferences()
        //{
        //    var conferences = db.HoiThaos
        //        .OrderBy(n => n.HoiThaoID)
        //        .ToList();

        //    return PartialView("_ConferencePartial", conferences);
        //}

        //public ActionResult LoadPapers()
        //{
        //    var papers = db.BaiBaos
        //        .OrderBy(n => n.BaiBaoID)
        //        .ToList();

        //    return PartialView("_PaperPartial", papers);
        //}

        public ActionResult LoadAuthors()
        {
            var authors = db.Users
                .Where(n => n.Role.RoleName.Equals("Author"))
                .OrderBy(n => n.UserID)
                .ToList();

            return PartialView("_AuthorPartial", authors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}