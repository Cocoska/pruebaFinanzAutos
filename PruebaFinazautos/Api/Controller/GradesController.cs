using Microsoft.AspNetCore.Mvc;
using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;
using PruebaFinazautos.Infrastructure.Repositories;

namespace PruebaFinazautos.Api.Controller
{
    public class GradesController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;

        public GradesController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grades>> GetGrades(int id)
        { 
            return await _gradeRepository.GetGradesById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Grades>> PostGrades(Grades grades)
        {
            await _gradeRepository.AddGrades(grades);
            return CreatedAtAction(nameof(GetGrades), new { id = grades.Id }, grades);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Grades>> PutGrades(int id, Grades grades)
        {
            if (id != grades.Id)
            {
                return BadRequest();
            }
            await _gradeRepository.UpdateGrades(grades);
            return NoContent();
        }

        public async Task<ActionResult<Grades>> DeleteGrades(int id)
        {
            await _gradeRepository.DeleteGrades(id);
            return NoContent();
        }
    }
}
