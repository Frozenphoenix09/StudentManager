using Microsoft.EntityFrameworkCore;
using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.EF;
using System.Linq.Dynamic.Core;

namespace StudentManager.DataAccess.Repositories
{
    public interface IStudentRepository : IBaseRepository<Entities.Student>
    {
        List<Entities.Student> GetAllStudent(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection , out int totalRecords);
    }
    public class StudentRepository : BaseRepository<Entities.Student>, IStudentRepository
    {
        public StudentRepository(StudentManagerDbContext context) : base(context)
        {

        }
        public List<Entities.Student> GetAllStudent(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection , out int totalRecords)
        {
            var query = Dbset.AsQueryable();

            if (textSearch != null)
            {
                query = query.Where(x => x.Name.Contains(textSearch) || x.Address.Contains(textSearch));
            }
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = query.OrderBy(string.Concat(sortColumn, " ", sortDirection));
            }
            else
            {
                query = query.OrderByDescending(x => x.StudentId);
            }
            query = query.Include(x => x.StudentClasses);
            totalRecords = query.Count();
            query = query.Skip(skip).Take(pageSize);
            return query.ToList();
        }
    }
}
