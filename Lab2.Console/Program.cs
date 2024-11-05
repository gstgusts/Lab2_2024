using Lab2.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new StudentDbContext();

            db.Database.EnsureCreated();

            var results = db.Students
                .Where(s => s.Name == "Gusts")
                .OrderBy(s => s.Surname)
                .Select(s => new { Name = s.Name, Surname = s.Surname });

            var result = from student in db.Students
                where student.Name == "Gusts"
                select new { Name = student.Name, Surname = student.Surname };

            var data = db.Students
                .OrderBy(s => s.Surname)
                .FirstOrDefault(s => s.Name == "Gusts");

            if (data != null)
            {
                System.Console.WriteLine(data.Surname);
            }

            //var data2 = db.Students
            //    .OrderBy(s => s.Surname)
            //    .First(s => s.Name == "Andris");

            var data3 = db.Students.SingleOrDefault(s => s.Name == "Andris");

            foreach (var student in results)
            {
                System.Console.WriteLine(student.Surname);
            }

            //var st = new Student
            //{
            //    Code = "GL03",
            //    Name = "Jānis",
            //    Surname = "Ozols",
            //    Grades = new List<Grade>
            //    {
            //        new Grade
            //        {
            //            Subject = "AAA",
            //            Value = 7
            //        }
            //    }
            //};

            //db.Students.Add(st);

            //db.SaveChanges();

            var jhon = db.Students.Include(s => s.Grades)
                .FirstOrDefault(s => s.Name == "Jānis");

            //jhon.Surname = "Kļava";

            //jhon.Grades.Add(new Grade
            //{
            //    Subject = "BBB",
            //    Value = 8,
            //    Comment = "ĻOti labs darbs"
            //});

            //jhon.Grades.RemoveAt(0);

            db.SaveChanges();

        }
    }
}
