using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.Entities;
using StudentManager.DataAccess.Repositories;
using StudentManager.Model.Model.StudentModels;
using StudentManager.Service.Mapper;

namespace StudentManager.Service.Service
{
    public interface IStudentService : IEntityService<Student>
    {
        List <StudentModel> GetAllStudent(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection , out int  totalRecords);
    }
    public class StudentService : EntityService<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository) : base(unitOfWork, studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentModel> GetAllStudent(int pageSize, int skip, string textSearch, string sortColumn, string sortDirection , out int  totalRecords)
        {
            return _studentRepository.GetAllStudent(pageSize, skip, textSearch, sortColumn, sortDirection , out totalRecords).MapToModels();
        }
    }
}
