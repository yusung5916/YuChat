using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class GenericRepository<T> : ViewRepository<T>, IRepository<T> where T : class
    {
        private readonly ChatRoomContext _db;

        public GenericRepository(ChatRoomContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Insert資料
        /// </summary>
        /// <param name="entity">Value</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException(entity.GetType().Name);
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        /// <summary>
        /// Update資料
        /// </summary>
        /// <param name="entity">Value</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(entity.GetType().Name);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Delete資料
        /// </summary>
        /// <param name="entity">Value</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(entity.GetType().Name);
            _db.Entry(entity).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        /// <summary>
        /// Select 單筆資料
        /// </summary>
        /// <param name="predicate">data => data.欄位ID = 資料</param>
        /// <returns></returns>
        public T? Get(Expression<Func<T, bool>> predicate) => _db.Set<T>().FirstOrDefault(predicate);
    }
}
