using PruebaFinazautos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinazautos.Core.Ports
{
    public interface IStudentsRepository
    {
        Task<Student> GetStudentById(int idStudent);
        Task AddStudent(Student student);
        Task DeleteStudent(int idStudent);
        Task<Student> UpdateStudent(Student student);
    }
}
