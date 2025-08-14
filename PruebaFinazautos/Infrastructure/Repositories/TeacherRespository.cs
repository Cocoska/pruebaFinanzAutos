using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;
using PruebaFinazautos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PruebaFinazautos.Infrastructure.Repositories
{
    public class TeacherRespository : ITeacherRepository
    {
        private FinanzAutosDbContext _context;

        public async Task AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacher(int idTeacher)
        {
            var teacher = await _context.Teachers.FindAsync(idTeacher);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Teacher> GetTeacherById(int idTeacher)
        {
            return await _context.Teachers.FindAsync(idTeacher);
        }

        public async Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
