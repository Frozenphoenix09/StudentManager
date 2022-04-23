using Microsoft.EntityFrameworkCore;
using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.EF;
using StudentManager.DataAccess.Entities;
using System.Linq.Dynamic.Core;

namespace StudentManager.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> GetAllUser(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection);
        bool Verify(User user , out string message);
        User GetByUserName(string userName);
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StudentManagerDbContext context) : base(context)
        {

        }

        public List<User> GetAllUser(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection)
        {
            var query = Dbset.AsQueryable();

            if (textSearch != null)
            {
                query = query.Where(x => x.UserName.Contains(textSearch) || x.Email.Contains(textSearch));
            }
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = query.OrderBy(string.Concat(sortColumn, " ", sortDirection));
            }
            query = query.Skip(skip).Take(pageSize);
            return query.ToList();
        }

        public User GetByUserName(string userName)
        {
            var query = Dbset.AsQueryable();
            var _user = query.Where(x => x.UserName == userName).FirstOrDefault();
            return _user;
        }

        public bool Verify(User user, out string message)
        {
            var query = Dbset.AsQueryable();
            var _user = query.Where(x => x.UserName == user.UserName).FirstOrDefault();
            if(_user != null)
            {
                if(_user.PasswordHash == user.PasswordHash)
                {
                    message = "Đăng nhập thành công !";
                    return true;
                }
            }
            message = "Đăng nhập thất bại ! UserName hoặc Password không chính xác !";
            return false;
        }
    }
}
