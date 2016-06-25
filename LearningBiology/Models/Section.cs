using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LearningBiology.Models
{
    public class Section
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public string VideoName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Paragraph> Paragraphs { get; set; }
        public virtual ICollection<Images> Images{ get; set; }
    }
   
}