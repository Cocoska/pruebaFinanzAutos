using PruebaFinazautos.Core.Entities;

namespace PruebaFinazautos.Core.Ports
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetTeacherById(int idTeacher);
        Task AddTeacher(Teacher teacher);
        Task DeleteTeacher(int idTeacher);
        Task<Teacher> UpdateTeacher(Teacher teacher);
    }
}
