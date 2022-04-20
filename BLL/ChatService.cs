using System.Linq.Expressions;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Entities;

namespace BLL
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _repository;

        public ChatService(IRepository<Chat> repository)
        {
            _repository = repository;
        }

        public void Create(Chat chat) => _repository.Create(chat);

        public void Update(Chat chat) => _repository.Update(chat);

        public void Delete(Chat chat) => _repository.Delete(chat);

        public Chat? Get(Expression<Func<Chat, bool>> predicate) => _repository.Get(predicate);
    }
}
