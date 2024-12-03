using Lab2.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.WebAPI.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private StudentDbContext _db;
        public GradesController()
        {
            _db = new StudentDbContext();
        }

        //students/1/grades
        [HttpGet()]
        [Route("{id}/Grades")]
        public Grade[] GetStudents(int id)
        {
            var data = _db.Grades.Where(g => g.Student.Id == id).ToArray();
            return data;
        }
    }
}
