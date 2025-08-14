using PruebaFinazautos.Core.Entities;

namespace PruebaFinazautos.Core.Ports
{
    public interface ICourseRespository
    {
        Task<Course> GetCourseById(int idCourse);
        Task AddCourse(Course course);
        Task DeleteCourse(int idCourse);
        Task<Course> UpdateCourse(Course course);
    }
}
