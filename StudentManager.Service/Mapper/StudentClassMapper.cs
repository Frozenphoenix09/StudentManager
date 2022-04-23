using StudentManager.DataAccess.Entities;
using StudentManager.Model.Model.StudentClassModels;

namespace StudentManager.Service.Mapper
{
    public static class StudentClassMapper
    {
        public static StudentClassModel MapToModel(this StudentClass entity)
        {
            return new StudentClassModel
            {
                StudentClassId = entity.StudentClassId,
                StudentId = entity.StudentId,
                ClassId = entity.ClassId,
                Student = entity.Student != null ? entity.Student.MapToModel() : null,
                Class = entity.Class != null ? entity.Class.MapToModel() : null
            };
        }
        public static StudentClass MapToEntity(this StudentClassModel model)
        {
            return new StudentClass
            {
                StudentClassId = model.StudentClassId,
                StudentId = model.StudentId,
                ClassId = model.ClassId
            };
        }
        public static List<StudentClassModel> MapToModels(this List<StudentClass> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
        public static List<StudentClass> MapToEntities(this List<StudentClassModel> entities)
        {
            return entities.Select(x => x.MapToEntity()).ToList();
        }

    }
}
