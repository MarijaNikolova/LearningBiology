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
    public class SectionsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Sections
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.active = section.ID;

            

            string content = section.Content.Replace("t","\t").Replace("-","");
            string [] pars = content.Split('w');
            string [] images=new string[pars.Length];
            for (int i = 0; i < pars.Count(); ++i)
            {
                try
                {
                    images[i] = section.Images.Where(p => p.ParagraphNumber == i).First().Title;
                }catch(Exception e)
                {
                    images[i] = null;
                }
            }

            ViewBag.count = pars.Length;
            ViewBag.paragraphs=pars;
            ViewBag.images = images;
            return View(section);

        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            // return View();
            return RedirectToAction("Index", "Home");
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ShortContent,Content,VideoName")] Section section)
        {
            /*if (ModelState.IsValid)
            {
                db.Sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(section);*/
            return RedirectToAction("Index", "Home");
        }

        // GET: Sections/Edit/5
        public ActionResult Edit(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section); */
            return RedirectToAction("Index", "Home");
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ShortContent,Content,VideoName")] Section section)
        {
            /* if (ModelState.IsValid)
             {
                 db.Entry(section).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(section); */
            return RedirectToAction("Index", "Home");

        }

        // GET: Sections/Delete/5
        public ActionResult Delete(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section); */
            return RedirectToAction("Index", "Home");
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*  Section section = db.Sections.Find(id);
             db.Sections.Remove(section);
             db.SaveChanges();
             return RedirectToAction("Index"); */
            return RedirectToAction("Index", "Home");
        }

        public ActionResult nextSection(int sectionId)
        {
            if (sectionId == 1)
            {
                return RedirectToAction("Details", new { id=2});
            }
            else if (sectionId == 2)
            {
                return RedirectToAction("Details", new { id = 3 });
            }
            else if (sectionId == 3)
            {
                return RedirectToAction("Details", new { id = 4 });
            }
            else if (sectionId == 4)
            {
                return RedirectToAction("Details", new { id = 5 });
            }
            else if (sectionId == 5)
            {
                return RedirectToAction("Details", new { id = 6 });
            }
            else
            {
                return RedirectToAction("Details", new { id = 1 });
            }

            
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
