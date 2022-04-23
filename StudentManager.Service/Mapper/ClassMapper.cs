using StudentManager.DataAccess.Entities;
using StudentManager.Model.Model.ClassModels;

namespace StudentManager.Service.Mapper
{
    public static class ClassMapper
    {
        public static Class MapToEntity(this ClassModel model)
        {
            return new Class
            {
                ClassName = model.ClassName,
                Capatity = model.Capatity
            };
        }
        public static ClassModel MapToModel(this Class entity)
        {
            return new ClassModel
            {
                ClassId = entity.ClassId,
                ClassName = entity.ClassName,
                Capatity = entity.Capatity,
                StudentClasses = entity.StudentClasses != null ? entity.StudentClasses.MapToModels() : null
            };
        }
        public static List<ClassModel> MapToModels(this List<Class> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
        public static List<Class> MapToEntities(this List<ClassModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
    }
}
