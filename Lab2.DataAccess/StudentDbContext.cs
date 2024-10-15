using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Lab2.DataAccess
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public StudentDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gusts\\source\\repos\\Lab2.DataAccess\\Lab2.DataAccess\\StudentDb.mdf;Integrated Security=True");

    }
}
