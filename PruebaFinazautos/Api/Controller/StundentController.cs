using Microsoft.AspNetCore.Mvc;
using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;

namespace PruebaFinazautos.Api.Controller
{
    [ApiController]
    [Route("api/Students")]
    public class StundentController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StundentController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentsRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _studentsRepository.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.idStudents}, student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            await _studentsRepository.DeleteStudent(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> PutStudent(int id, Student student)
        {
            if (id != student.idStudents)
            {
                return BadRequest();
            }
            await _studentsRepository.UpdateStudent(student);
            return NoContent();
        }
    }
}
