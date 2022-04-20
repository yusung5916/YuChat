using System.Linq.Expressions;
using DAL.Interfaces;
using Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User? Get(Expression<Func<User, bool>> predicate);
    }
}
