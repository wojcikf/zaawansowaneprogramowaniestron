using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektWojcik.Models;

namespace ProjektWojcik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static List<Student> students = new List<Student> {

            new Student(){id = 1, FirstName = "Ala", LastName="Kot", Grant=1234},
            new Student(){ id = 1, FirstName = "Ala", LastName = "Kot", Grant = 1234},
        };

        // GET: api/Students
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var student = students.SingleOrDefault(s => s.id == id);
            if (student != null)
                return Ok(student);
            else
                return NotFound();

        }

        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody] Student student) {
            student.id = students.Last().id + 1;
            students.Add(student);

            return CreatedAtRoute("Get", new { id = student.id }, student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
