using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class OfferedAswer
    {
        public int ID { get; set; }
        public int QuestionID { set; get; }
        public int AnswerID { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }

        public override string ToString()
        {
            return "";
        }

    }
}