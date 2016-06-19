using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class UserAnswer
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}