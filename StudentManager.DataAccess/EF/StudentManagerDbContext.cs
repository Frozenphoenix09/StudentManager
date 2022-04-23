using Microsoft.EntityFrameworkCore;
using StudentManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.DataAccess.EF
{
    public class StudentManagerDbContext : DbContext
    {
        public StudentManagerDbContext(DbContextOptions<StudentManagerDbContext> opt) : base(opt)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
