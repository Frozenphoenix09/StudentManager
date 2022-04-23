using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.EF;
using StudentManager.DataAccess.Entities;

namespace StudentManager.DataAccess.Repositories
{
    public interface IStudentClassRepository : IBaseRepository<StudentClass>
    {

    }
    public class StudentClassRepository : BaseRepository<StudentClass>, IStudentClassRepository
    {
        public StudentClassRepository(StudentManagerDbContext context) : base(context)
        {

        }
    }
}
