using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class ViewRepository<T> : IViewRepository<T> where T : class
    {
        private readonly ChatRoomContext _db;

        public ViewRepository(ChatRoomContext db)
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
