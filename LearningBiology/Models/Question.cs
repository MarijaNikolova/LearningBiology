using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class Question
    {
        public int ID { get; set; } 
        public string text { get; set; }
        public int sectionID { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<OfferedAswer> OfferedAnswers { get; set; }
    }
}