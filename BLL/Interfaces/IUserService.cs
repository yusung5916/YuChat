using DAL.Interfaces;
using Entities;

namespace BLL.Interfaces
{
    public interface IUserService : IRepository<User>
    {
        User? Get(string email);
    }
}
