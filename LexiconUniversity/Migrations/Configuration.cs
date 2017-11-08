namespace LexiconUniversity.Migrations
{
    using LexiconUniversity.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconUniversity.DataAccess.LexiconUniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LexiconUniversity.DataAccess.LexiconUniversityContext";
        }

        protected override void Seed(LexiconUniversity.DataAccess.LexiconUniversityContext context)
        {

            context.Courses.AddOrUpdate(
              c => c.CourseId, //new { c.CourseId, Name},
              new Course { CourseId = "PP123", Credit = 0, Name = "PHP for Poets" },
              new Course { CourseId = "DN123", Credit = 0, Name = "DotNet for Accountants" },
              new Course { CourseId = "JE123", Credit = 0, Name = "Java for you" }
            );

            Student[] students = new[]
            {
                new Student { FirstName = "Adam", LastName = "Adamsson" },
                new Student { FirstName = "Lars", LastName = "Larsson" },
                new Student { FirstName = "Sven", LastName = "Svensson" }
            };

            context.Students.AddOrUpdate(s => new { s.FirstName, s.LastName }, students);
            context.SaveChanges();

            context.Enrollments.AddOrUpdate(
                 e => new { e.CourseId, e.StudentId },
                //new Enrollment { CourseId = "PP123", StudentId = context.Students.Where(s => s.FirstName == "Adam " && s.LastName = "Adamsson").First().Id }
                new Enrollment { CourseId = "PP123", StudentId = students[0].Id },
                new Enrollment { CourseId = "PP123", StudentId = students[1].Id },
                new Enrollment { CourseId = "PP123", StudentId = students[2].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[0].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[1].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[2].Id }
               );
        }
    }
}
