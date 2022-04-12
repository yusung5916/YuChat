using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    internal class MsgDataService : GenericRepository<MsgDatum>, IMsgDataService
    {
        private readonly ChatRoomContext _db;

        public MsgDataService(ChatRoomContext db) : base(db)
        {
            _db = db;
        }

    }
}
