using System.Linq.Expressions;
using DAL.Interfaces;
using Entities;

namespace BLL.Interfaces
{
    public interface IChatUserService
    {
        void Create(ChatUser chatUser);
        void Update(ChatUser chatUser);
        void Delete(ChatUser chatUser);
        ChatUser? Get(Expression<Func<ChatUser, bool>> predicate);
        IQueryable<Chat> GetUserChatList(int userId);
    }
}
