using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagerWebApp.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\BAOVIET;Database=SchoolDB;Trusted_Connection=True;");
        //}
    }
}
