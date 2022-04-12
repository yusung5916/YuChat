using DAL.Interfaces;
using Entities;

namespace BLL.Interfaces
{
    public interface IChatUserService : IRepository<ChatUser>
    {
        IQueryable<Chat> GetUserChatList(int userId);
    }
}
