using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    public class ChatService : GenericRepository<Chat>, IChatService
    {
        private readonly ChatRoomContext _db;

        public ChatService(ChatRoomContext db) : base(db)
        {
            _db = db;
        }
        
    }
}
