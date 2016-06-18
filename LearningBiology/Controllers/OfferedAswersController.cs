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
    public class OfferedAswersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: OfferedAswers
        public ActionResult Index()
        {
            var offeredAnswers = db.OfferedAnswers.Include(o => o.Answer).Include(o => o.Question);
            return View(offeredAnswers.ToList());
        }

        // GET: OfferedAswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferedAswer offeredAswer = db.OfferedAnswers.Find(id);
            if (offeredAswer == null)
            {
                return HttpNotFound();
            }
            return View(offeredAswer);
        }

        // GET: OfferedAswers/Create
        public ActionResult Create()
        {
            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "text");
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "text");
            return View();
        }

        // POST: OfferedAswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuestionID,AnswerID")] OfferedAswer offeredAswer)
        {
            if (ModelState.IsValid)
            {
                db.OfferedAnswers.Add(offeredAswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "text", offeredAswer.AnswerID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "text", offeredAswer.QuestionID);
            return View(offeredAswer);
        }

        // GET: OfferedAswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferedAswer offeredAswer = db.OfferedAnswers.Find(id);
            if (offeredAswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "text", offeredAswer.AnswerID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "text", offeredAswer.QuestionID);
            return View(offeredAswer);
        }

        // POST: OfferedAswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QuestionID,AnswerID")] OfferedAswer offeredAswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offeredAswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "text", offeredAswer.AnswerID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "text", offeredAswer.QuestionID);
            return View(offeredAswer);
        }

        // GET: OfferedAswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferedAswer offeredAswer = db.OfferedAnswers.Find(id);
            if (offeredAswer == null)
            {
                return HttpNotFound();
            }
            return View(offeredAswer);
        }

        // POST: OfferedAswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferedAswer offeredAswer = db.OfferedAnswers.Find(id);
            db.OfferedAnswers.Remove(offeredAswer);
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
