using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public enum Type
    {
        OneChoice, MultipleAnswers, DragAndDrop
    }

    public class Question
    {
        public int ID { get; set; } 
        public string text { get; set; }
        public int sectionID { get; set; }
        public Type? Type { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<OfferedAswer> OfferedAnswers { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}