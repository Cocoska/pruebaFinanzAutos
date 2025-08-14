using Microsoft.AspNetCore.Mvc;
using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;

namespace PruebaFinazautos.Api.Controller
{
    [ApiController]
    [Route("api/Teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int idTeacher)
        {
            var teacher = await teacherRepository.GetTeacherById(idTeacher);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            teacherRepository.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.idTacher}, teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.idTacher)
            {
                return BadRequest();
            }
            await teacherRepository.UpdateTeacher(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int idTeacher)
        {
            await teacherRepository.DeleteTeacher(idTeacher);
            return NoContent();
        }
    }
}
