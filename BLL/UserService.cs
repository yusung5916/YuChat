using BLL.Interfaces;
using DAL;
using Entities;

namespace BLL
{
    public class UserService : GenericRepository<User>, IUserService
    {
        private readonly ChatRoomContext _db;
        public UserService(ChatRoomContext db) : base(db)
        {
            this._db = db;
        }

        public User? Get(string email) => _db.Users.FirstOrDefault(user => user.Email == email);
    }
}
