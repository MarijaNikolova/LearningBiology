﻿using System;
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
        public string Content { get; set; }


        public virtual ICollection<Question> Questions { get; set; }
    }
   
}