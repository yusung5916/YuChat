using Entities;

namespace BLL.Interfaces
{
    public interface IChatMsg
    {
        IQueryable<VwuserToChatMsg> GetMsg(int chatID);
    }
}
