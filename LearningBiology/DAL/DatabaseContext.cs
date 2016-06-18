using LearningBiology.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearningBiology.DAL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {

        }

        public DbSet<Section> Sections { get; set;  }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<OfferedAswer> OfferedAnswers { get; set; }
    }
}