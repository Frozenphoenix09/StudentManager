using StudentManager.DataAccess.Entities;
using StudentManager.Model.Model.UserModel;

namespace StudentManager.Service.Mapper
{
    public static class UserMapper
    {
        public static UserModel MapToModel(this User entity)
        {
            return new UserModel
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                Email = entity.Email,
                Salt = entity.Salt
            };
        }
        public static User MapToEntity(this UserModel model)
        {
            return new User
            {
                UserName = model.UserName,
                Email = model.Email   ,
                PasswordHash = model.Password,
          
            };
        }
        public static List<User> MapToEntities (this List<UserModel> models)
        {
            return models.Select(x=>x.MapToEntity()).ToList();
        }
        public static List<UserModel> MapToModels(this List<User> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}
