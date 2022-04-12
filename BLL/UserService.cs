using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    public class UserService : GenericRepository<User>, IUserService
    {
        public UserService(ChatRoomContext db) : base(db)
        {
        }

        public User? Get(string email) => GetAll().FirstOrDefault(user => user.Email == email);
    }
}
