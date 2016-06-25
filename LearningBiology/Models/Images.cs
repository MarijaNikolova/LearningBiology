using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class Images
    {
        public int ID { get; set; }
        public int SectionID { get; set; }
        public int ParagraphNumber { get; set; }
        public string Title {get; set;}

        public virtual Section Section { get; set; }
    }
}