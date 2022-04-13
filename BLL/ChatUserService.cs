using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    public class ChatUserService : GenericRepository<ChatUser>, IChatUserService
    {

        public ChatUserService(ChatRoomContext db) : base(db)
        {
        }

        public IQueryable<Chat> GetUserChatList(int userId) =>
            GetAll().Where(chatUser => chatUser.UserId == userId).Select(chatUser => chatUser.Chat);
    }
}
