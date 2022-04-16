using DAL.Interfaces;
using Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
        User? Get(int userId);
        User? Get(string email);
    }
}
