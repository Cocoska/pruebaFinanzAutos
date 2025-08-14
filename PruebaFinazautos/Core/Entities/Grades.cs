namespace PruebaFinazautos.Core.Entities
{
    public class Grades
    {
        public int Id { get; set; }
        public int IdStudents { get; set; }
        public decimal Grade { get; set; }
        public int IdCourse { get; set; }
        public int IdTeacher { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
    }
}
