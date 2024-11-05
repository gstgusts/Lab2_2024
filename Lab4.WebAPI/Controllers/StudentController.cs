using Lab2.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentDbContext _db;
        public StudentController()
        {
            _db = new StudentDbContext();
        }

        [HttpGet]
        public Student[] GetStudents()
        {
            var data = _db.Students.ToArray();
            return data;
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            var data = _db.Students.FirstOrDefault(s => s.Id == id);
            return data;
        }

        [HttpGet("filtered")]
        public Student[] GetStudents([FromQuery] string name)
        {
            var data = _db.Students.Where(s => s.Name.Contains(name)).ToArray();
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateStudent([FromBody] Student student, int id)
        {
            var existingStudent = _db.Students.FirstOrDefault(s => s.Id == id);

            if (existingStudent != null)
            {
                existingStudent.Code = student.Code;
                existingStudent.Name = student.Name;
                existingStudent.Surname = student.Surname;
            }

            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            var data = _db.Students.FirstOrDefault(s => s.Id == id);

            if (data != null)
            {
                _db.Students.Remove(data);
                _db.SaveChanges();
            }
        }
    }
}
