using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;
using PruebaFinazautos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PruebaFinazautos.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private FinanzAutosDbContext _context;
        public GradeRepository(FinanzAutosDbContext context)
        {
            _context = context;
        }

        public async Task AddGrades(Grades grades)
        {
            _context.Grades.Add(grades);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGrades(int idGrades)
        {
            var grades = _context.Grades.FindAsync(idGrades);
            if (grades != null)
            {
                _context.Grades.Remove(idGrades);
                _context.SaveChangesAsync();
            }
        }

        public async Task<Grades> GetGradesById(int idGrades)
        {
            return await _context.Grades.FindAsync(idGrades);
        }

        public async Task<Grades> UpdateGrades(Grades grades)
        {
            _context.Entry(grades).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return grades;
        }
    }
}
