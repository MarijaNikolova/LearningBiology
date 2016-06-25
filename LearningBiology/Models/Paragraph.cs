using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class Paragraph
    {
    
        public int ID { get; set; }
        public int SectionID { get; set; }
        public bool HasPicture { get; set; }
        public String pictureName { get; set; }
        public String content { get; set; }

        public virtual Section Section { get; set; }
    }
}