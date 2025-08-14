using Microsoft.AspNetCore.Mvc;
using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;

namespace PruebaFinazautos.Api.Controller
{
    public class CourseController : ControllerBase
    {
        private readonly ICourseRespository _courseRespository;

        public CourseController (ICourseRespository courseRespository)
        {
            _courseRespository = courseRespository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int idCourse)
        {
            return await _courseRespository.GetCourseById(idCourse);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            await _courseRespository.AddCourse(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.idCourse }, course);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            await _courseRespository.DeleteCourse(id);
            return NoContent();
        }

        [HttpPut("id")]
        public async Task<ActionResult<Course>> PutCourse(int id, Course course)
        {
            if (id != course.idCourse)
            {
                return BadRequest();
            }
            await _courseRespository.UpdateCourse(course);
            return NoContent();
        }
    }
}
