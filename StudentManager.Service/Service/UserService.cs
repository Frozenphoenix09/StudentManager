using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.Entities;
using StudentManager.DataAccess.Repositories;
using StudentManager.Model.Model.UserModel;
using StudentManager.Service.Mapper;

namespace StudentManager.Service.Service
{
    public interface IUserService : IEntityService<User>
    {
        List<UserModel> GetAllUser(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection);
        bool Verify(UserModel user, out string message);
        UserModel GetByUserName(string userName);
    }
    public class UserService : EntityService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork, userRepository)
        {
            _userRepository = userRepository;
            ;
        }
        public List<UserModel> GetAllUser(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection)
        {

            return _userRepository.GetAllUser(pageSize, skip, textSearch, sortColumn, sortDirection).MapToModels();

        }

        public UserModel GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName).MapToModel();
        }

        public bool Verify(UserModel user, out string message)
        {
            return _userRepository.Verify(user.MapToEntity(),out message);
        }
    }
}
