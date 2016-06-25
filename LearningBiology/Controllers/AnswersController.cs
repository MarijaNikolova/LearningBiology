﻿using System;
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
    public class AnswersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Answers
        public ActionResult Index()
        {
            //return View(db.Answers.ToList());
            return RedirectToAction("Index", "Home");
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer); */
            return RedirectToAction("Index", "Home");
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            //return View();
            return RedirectToAction("Index", "Home");
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,text")] Answer answer)
        {
            /*if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(answer); */
            return RedirectToAction("Index", "Home");
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            /* if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Answer answer = db.Answers.Find(id);
             if (answer == null)
             {
                 return HttpNotFound();
             }
             return View(answer); */
            return RedirectToAction("Index", "Home");
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,text")] Answer answer)
        {
            /*if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(answer); */
            return RedirectToAction("Index", "Home");
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            /* if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Answer answer = db.Answers.Find(id);
             if (answer == null)
             {
                 return HttpNotFound();
             }
             return View(answer);*/
            return RedirectToAction("Index", "Home");
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
            db.SaveChanges();
            return RedirectToAction("Index"); */
            return RedirectToAction("Index", "Home");
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
