using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.Entities;
using StudentManager.DataAccess.Repositories;

namespace StudentManager.Service.Service
{
    public interface IStudentClassService : IEntityService<StudentClass>
    {

    }
    public class StudentClassService : EntityService<StudentClass>, IStudentClassService
    {
        private readonly IStudentClassRepository _studentClassRepository;
        public StudentClassService(IUnitOfWork unitOfWork, IStudentClassRepository studentClassRepository) : base(unitOfWork, studentClassRepository)
        {
            _studentClassRepository = studentClassRepository;
        }
    }
}
