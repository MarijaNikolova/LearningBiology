using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class QuestionAnswerViewModel
    {
        public int ID { set; get; }
        public int QuestionID { set; get; }
        public int AnswerID { set; get; }
        public bool IsCorrect { set; get; }

    }
}