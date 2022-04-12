using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    internal class MsgDataService : GenericRepository<MsgDatum>, IMsgDataService
    {

        public MsgDataService(ChatRoomContext db) : base(db)
        {
        }

    }
}
