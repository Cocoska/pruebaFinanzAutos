using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using PruebaFinazautos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinazautos.Infrastructure.Data
{
    public class FinanzAutosDbContext : DbContext
    {
        public FinanzAutosDbContext(DbContextOptions<FinanzAutosDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Student>().HasKey(s => s.idStudents);
        }
    }
}
