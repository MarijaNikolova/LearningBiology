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
    public class QuestionsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Questions
        public ActionResult Index(int sectionId = 1)
        {
            var questions = db.Questions.Include(q => q.Section);
            questions = questions.Where(q => q.sectionID == sectionId);
            Question firstQuestion = questions.First();
            return RedirectToAction("Details", new { id = firstQuestion.ID, message = "" });
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id, string message="")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.message = message;
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.sectionID = new SelectList(db.Sections, "ID", "Name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,text,sectionID,Type")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sectionID = new SelectList(db.Sections, "ID", "Name", question.sectionID);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.sectionID = new SelectList(db.Sections, "ID", "Name", question.sectionID);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,text,sectionID,Type")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sectionID = new SelectList(db.Sections, "ID", "Name", question.sectionID);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckAnswers(FormCollection model)
        {

            if (model != null)
            {

                /* for (int i = 0; i < model.Count(); ++i)
                 {
                     OfferedAswer answer = model.ElementAt(i);
                     int ID = answer.ID;
                     OfferedAswer oa = db.OfferedAnswers.Find(ID);
                     if (answer.IsCorrect != oa.IsCorrect)
                     {

                         return "Not correct";
                     }
                 }
                 return "Correct!"; */

                // @Html.CheckBoxFor(m => m.OfferedAnswers.ElementAt(i).IsCorrect)
                //                        @Html.CheckBox("IsCorrect", false, htmlAttributes: new { @class = "form-control" })
                //String id = model["ID"];
                //if(id!=null)
                //String[] IDs= id.Split(',');

              
                String answerIds = model["AnswerID"];
                String[] answerIDs;
                if (answerIds!=null)
                answerIDs = answerIds.Split(',');


                String questionIds = model["QuestionID"];
                //String[] questionIDs = questionIds.Split(',');
               // int idQuestion = Int32.Parse(questionIDs[0]);

                String selected = model["isSelected"];
                String[] selectedAnswers;
                int[] idsAnsweredQuestions;
                if (selected != null && questionIds!=null)
                {
                  
                    String[] questionIDs = questionIds.Split(',');
                    int idQuestion = Int32.Parse(questionIDs[0]);
                    selectedAnswers = selected.Split(',');
                    idsAnsweredQuestions = new int[selectedAnswers.Count()];
                    for(int i = 0; i < selectedAnswers.Count(); ++i)
                    {
                        idsAnsweredQuestions[i] = Int32.Parse(selectedAnswers.ElementAt(i));
                    }
                    Question question = db.Questions.Find(idQuestion);


                    var answers = question.OfferedAnswers.Where(q=>q.IsCorrect==true);

                   

                    int count = 0;
                    if(idsAnsweredQuestions.Count()==0 || answers.Count()>idsAnsweredQuestions.Count())
                    {
                        return RedirectToAction("Details", new { id = idQuestion, message="Некомплетен одговор." });
                    }
                    for (int i = 0; i < idsAnsweredQuestions.Count(); ++i)
                    {
                        OfferedAswer answer = db.OfferedAnswers.Find(idsAnsweredQuestions[i]);
                        if (!answer.IsCorrect)
                        {
                            return RedirectToAction("Details", new { id =idQuestion,message="Неточен одговор." });
                        }
                        else
                        {
                            ++count;
                        }
                    }
                    // ViewBag["id"] = idQuestion;
                    //return View("CorrectAnswer");
                    
                    return RedirectToAction("NextQuestion", new { id = idQuestion,sectionId=question.sectionID});
                }

            }



            return View("CorrectAnswer");
        }


        public ActionResult NextQuestion(int id,int sectionId)
        {

            var questions = from q in db.Questions
                            select q;

           
            questions = questions.Where(q=>q.sectionID==sectionId).OrderByDescending(q => q.ID);

            Question last = questions.First();
            Question question;
            if (id!=last.ID)
            {
                questions = questions.Where(q => q.ID > id).OrderBy(q => q.ID).Take(1);
            }else
            {
                questions = questions.OrderBy(q => q.ID);
               
            }
            
          
            question = questions.First();


            return RedirectToAction("Details", new { id = question.ID });


           
        }

        public PartialViewResult showPopUp(String result)
        {
            return PartialView();
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
