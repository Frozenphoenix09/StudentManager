using StudentManager.DataAccess.Entities;
using StudentManager.Model.Model.StudentModels;


namespace StudentManager.Service.Mapper
{
    public static class StudentMapper
    {
        public static StudentModel MapToModel(this Student entity)
        {
            return new StudentModel
            {
                StudentId = entity.StudentId,
                Name = entity.Name,
                DateOfBirth = entity.DateOfBirth,
                Address = entity.Address,
                StudentClasses = entity.StudentClasses != null ? entity.StudentClasses.MapToModels() : null,
            };
        }
        public static Student MapToEntity(this StudentModel model)
        {
            return new Student
            {
                StudentId = model.StudentId,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
            };
        }
        public static List<StudentModel> MapToModels(this List<Student> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
        public static List<Student> MapToEntities(this List<StudentModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
    }
}
