using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.EF;
using StudentManager.DataAccess.Entities;

namespace StudentManager.DataAccess.Repositories
{
    public interface IClassRepository : IBaseRepository<Class>
    {

    }
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(StudentManagerDbContext context) : base(context)
        {

        }
    }
}
