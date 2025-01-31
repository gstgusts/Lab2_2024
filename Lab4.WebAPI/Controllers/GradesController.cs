﻿using System.Net;
using Lab2.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpDelete("{id}/Grades/{gradeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGrade(int id, int gradeId)
        {
            var data = _db.Grades
                .Include(g => g.Student)
                .FirstOrDefault(s => s.Id == gradeId);

            if (data == null) return NotFound();

            if (data.Student.Id != id) return BadRequest();

            _db.Grades.Remove(data);
            _db.SaveChanges();

            return Ok();
        }
    }
}
