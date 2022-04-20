using System.Linq.Expressions;
using DAL.Interfaces;
using Entities;

namespace BLL.Interfaces
{
    public interface IChatService
    {
        void Create(Chat chat);
        void Update(Chat chat);
        void Delete(Chat chat);
        Chat? Get(Expression<Func<Chat, bool>> predicate);
    }
}
