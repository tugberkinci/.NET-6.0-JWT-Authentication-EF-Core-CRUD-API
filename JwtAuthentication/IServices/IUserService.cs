using JwtAuthentication.Models;

namespace JwtAuthentication.IServices
{
    public interface IUserService
    {
        object GetAllData();
        object Post(UserModel model);
        object GetById(int id);
        object Delete(int id);
        object Update(int id, UserModel model);
    }
}
