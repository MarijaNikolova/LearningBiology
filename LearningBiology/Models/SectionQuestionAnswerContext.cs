using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearningBiology.Models
{
    public class SectionQuestionAnswerContext:DbContext
    {
        public DbSet<Section> sections { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }

    }
}