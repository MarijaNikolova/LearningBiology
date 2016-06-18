using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string text { get; set; }

        public virtual ICollection<OfferedAswer>  OfferedAnswers{get; set;}
    }
}