using Microsoft.EntityFrameworkCore;
using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;
using PruebaFinazautos.Infrastructure.Data;

namespace PruebaFinazautos.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRespository
    {
        private FinanzAutosDbContext _context;
        public CourseRepository(FinanzAutosDbContext context)
        {
            _context = context;
        }

        public async Task AddCourse(Course Course)
        {
            _context.Course.Add(Course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(int idCourse)
        {
            var course = await _context.Course.FindAsync(idCourse);
            if (course != null)
            {
                _context.Course.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Course> GetCourseById(int idCourse)
        {
            return await _context.Course.FindAsync(idCourse);
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
