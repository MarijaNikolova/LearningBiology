using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningBiology.DAL;
using LearningBiology.Models;

namespace LearningBiology.Controllers
{
    public class ParagraphsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Paragraphs
        public ActionResult Index()
        {
            var paragraphs = db.Paragraphs.Include(p => p.Section);
            return View(paragraphs.ToList());
        }

        // GET: Paragraphs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paragraph paragraph = db.Paragraphs.Find(id);
            if (paragraph == null)
            {
                return HttpNotFound();
            }
            return View(paragraph);
        }

        // GET: Paragraphs/Create
        public ActionResult Create()
        {
            ViewBag.SectionID = new SelectList(db.Sections, "ID", "Name");
            return View();
        }

        // POST: Paragraphs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SectionID,HasPicture,pictureName,content")] Paragraph paragraph)
        {
            if (ModelState.IsValid)
            {
                db.Paragraphs.Add(paragraph);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectionID = new SelectList(db.Sections, "ID", "Name", paragraph.SectionID);
            return View(paragraph);
        }

        // GET: Paragraphs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paragraph paragraph = db.Paragraphs.Find(id);
            if (paragraph == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionID = new SelectList(db.Sections, "ID", "Name", paragraph.SectionID);
            return View(paragraph);
        }

        // POST: Paragraphs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SectionID,HasPicture,pictureName,content")] Paragraph paragraph)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paragraph).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectionID = new SelectList(db.Sections, "ID", "Name", paragraph.SectionID);
            return View(paragraph);
        }

        // GET: Paragraphs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paragraph paragraph = db.Paragraphs.Find(id);
            if (paragraph == null)
            {
                return HttpNotFound();
            }
            return View(paragraph);
        }

        // POST: Paragraphs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paragraph paragraph = db.Paragraphs.Find(id);
            db.Paragraphs.Remove(paragraph);
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
