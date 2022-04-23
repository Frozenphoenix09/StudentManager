using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.Entities;
using StudentManager.DataAccess.Repositories;

namespace StudentManager.Service.Service
{
    public interface IClassService : IEntityService<Class>
    {

    }
    public class ClassService : EntityService<Class>, IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IUnitOfWork unitOfWork, IClassRepository classRepository) : base(unitOfWork, classRepository)
        {
            _classRepository = classRepository;
        }
    }
}
