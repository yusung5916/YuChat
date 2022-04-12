using BLL.Interfaces;
using Entities;

namespace BLL
{
    internal class ChatMsg : IChatMsg
    {
        private ChatRoomContext _db;

        public ChatMsg(ChatRoomContext db)
        {
            _db = db;
        }

        public IQueryable<VwuserToChatMsg> GetMsg(int chatID) =>
            _db.VwuserToChatMsgs.Where(data => data.ChatId == chatID);
    }
}
