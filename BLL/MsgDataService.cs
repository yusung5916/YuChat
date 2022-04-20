using System.Linq.Expressions;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Entities;

namespace BLL
{
    internal class MsgDataService : IMsgDataService
    {
        private readonly IRepository<MsgDatum> _repository;

        public MsgDataService(IRepository<MsgDatum> repository)
        {
            _repository = repository;
        }

        public void Create(MsgDatum msgDatum) => _repository.Create(msgDatum);

        public void Update(MsgDatum msgDatum) => _repository.Update(msgDatum);

        public void Delete(MsgDatum msgDatum) => _repository.Delete(msgDatum);

        public MsgDatum? Get(Expression<Func<MsgDatum, bool>> predicate) => _repository.Get(predicate);
    }
}
