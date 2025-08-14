using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PruebaFinazautos.Core.Entities;
using PruebaFinazautos.Core.Ports;
using PruebaFinazautos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinazautos.Infrastructure.Repositories
{
    public class StudentRepository : IStudentsRepository
    {
        private FinanzAutosDbContext _context;

        public StudentRepository(FinanzAutosDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentById(int idStudent)
        {
            return await _context.Students.FindAsync(idStudent);
        }

        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int idStudent)
        {
            var student = await _context.Students.FindAsync(idStudent);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
