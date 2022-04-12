using DAL.Interfaces;
using Entities;

namespace BLL
{
    public class ViewService<T> : IViewRepository<T> where T : class
    {
        private readonly ChatRoomContext _db;

        public ViewService(ChatRoomContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 撈出全部資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll() => _db.Set<T>().AsQueryable();
    }
}
