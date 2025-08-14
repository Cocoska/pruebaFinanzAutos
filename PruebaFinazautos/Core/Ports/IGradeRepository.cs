using PruebaFinazautos.Core.Entities;
using System.Diagnostics;

namespace PruebaFinazautos.Core.Ports
{
    public interface IGradeRepository
    {
        Task<Grades> GetGradesById(int idGrades);
        Task AddGrades(Grades grades);
        Task DeleteGrades(int idGrades);
        Task<Grades> UpdateGrades(Grades grades);
    }
}
