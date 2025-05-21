using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;

namespace Do_An.Areas.Author.Controllers
{
    public class PaperController : Controller
    {
        private DB_QLHTEntities db = new DB_QLHTEntities();

        // GET: Author/Paper
        public ActionResult Index()
        {
            var papers = db.Papers.ToList();
            return View(papers);
        }

        // GET: Author/Paper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // GET: Author/Paper/Create
        public ActionResult Create()
        {
            ViewBag.ConferenceID = new SelectList(db.Conferences, "ConferenceID", "Title");
            ViewBag.PrimaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName");
            ViewBag.SecondaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName");
            return View();
        }

        // POST: Author/Paper/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperID,ConferenceID,Title,Abstract,PrimaryAreaID,SecondaryAreaID,Keywords,CreatedAt,UpdatedAt")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Papers.Add(paper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConferenceID = new SelectList(db.Conferences, "ConferenceID", "Title", paper.ConferenceID);
            ViewBag.PrimaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName", paper.PrimaryAreaID);
            ViewBag.SecondaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName", paper.SecondaryAreaID);
            return View(paper);
        }

        // GET: Author/Paper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConferenceID = new SelectList(db.Conferences, "ConferenceID", "Title", paper.ConferenceID);
            ViewBag.PrimaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName", paper.PrimaryAreaID);
            ViewBag.SecondaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName", paper.SecondaryAreaID);
            return View(paper);
        }

        // POST: Author/Paper/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperID,ConferenceID,Title,Abstract,PrimaryAreaID,SecondaryAreaID,Keywords,CreatedAt,UpdatedAt")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paper).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConferenceID = new SelectList(db.Conferences, "ConferenceID", "Title", paper.ConferenceID);
            ViewBag.PrimaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName", paper.PrimaryAreaID);
            ViewBag.SecondaryAreaID = new SelectList(db.ResearchAreas, "AreaID", "AreaName", paper.SecondaryAreaID);
            return View(paper);
        }

        // GET: Author/Paper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Author/Paper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paper paper = db.Papers.Find(id);
            db.Papers.Remove(paper);
            db.SaveChanges();
            return RedirectToAction("Index");
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
