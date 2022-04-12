using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    internal class ChatUserService : GenericRepository<ChatUser>, IChatUserService
    {
        private readonly ChatRoomContext _db;

        public ChatUserService(ChatRoomContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Chat> GetUserChatList(int userId) =>
            _db.ChatUsers.Where(chatUser => chatUser.UserId == userId).Select(chatUser => chatUser.Chat);
    }
}
