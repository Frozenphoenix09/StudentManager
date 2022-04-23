using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.DataAccess.EF
{
    public class StudentManagerDbContextFactory : IDesignTimeDbContextFactory<StudentManagerDbContext>
    {
        public StudentManagerDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<StudentManagerDbContext>();
            optionBuilder.UseSqlServer("Server=DESKTOP-QLHOVH5\\DATHUNG;Initial Catalog=StudentMangement;User Id=dathung091;Password=12344321;");
            return new StudentManagerDbContext(optionBuilder.Options);
        }
    }
}
