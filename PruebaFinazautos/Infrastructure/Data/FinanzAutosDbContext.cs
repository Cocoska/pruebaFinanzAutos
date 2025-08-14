using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using PruebaFinazautos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinazautos.Infrastructure.Data
{
    public class FinanzAutosDbContext : DbContext
    {
        public FinanzAutosDbContext(DbContextOptions<FinanzAutosDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Grades> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Student>().HasKey(s => s.idStudents);
            modelbuilder.Entity<Teacher>().HasKey(s => s.idTacher);
            modelbuilder.Entity<Course>().HasKey(s => s.idCourse);
            modelbuilder.Entity<Grades>().HasKey(s => s.Id);

            modelbuilder.Entity<Grades>().HasOne(s => s.Student).WithMany().HasForeignKey(g => g.IdStudents);
            modelbuilder.Entity<Grades>().HasOne(s => s.Course).WithMany().HasForeignKey(g => g.IdCourse);
            modelbuilder.Entity<Grades>().HasOne(s => s.Teacher).WithMany().HasForeignKey(g => g.IdTeacher);           
        }
    }
}
