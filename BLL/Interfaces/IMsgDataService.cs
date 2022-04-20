using System.Linq.Expressions;
using DAL.Interfaces;
using Entities;

namespace BLL.Interfaces
{
    public interface IMsgDataService
    {
        void Create(MsgDatum msgDatum);
        void Update(MsgDatum msgDatum);
        void Delete(MsgDatum msgDatum);
        MsgDatum? Get(Expression<Func<MsgDatum, bool>> predicate);
    }
}
