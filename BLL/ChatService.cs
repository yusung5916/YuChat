using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    public class ChatService : GenericRepository<Chat>, IChatService
    {

        public ChatService(ChatRoomContext db) : base(db)
        {
        }
        
    }
}
