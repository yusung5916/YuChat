using System.Linq.Expressions;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Entities;

namespace BLL
{
    public class ChatUserService : IChatUserService
    {
        private readonly IRepository<ChatUser> _repository;

        public ChatUserService(IRepository<ChatUser> repository)
        {
            _repository = repository;
        }

        public void Create(ChatUser chatUser) => _repository.Create(chatUser);

        public void Update(ChatUser chatUser) => _repository.Update(chatUser);

        public void Delete(ChatUser chatUser) => _repository.Delete(chatUser);

        public ChatUser? Get(Expression<Func<ChatUser, bool>> predicate) => _repository.Get(predicate);

        public IQueryable<Chat> GetUserChatList(int userId) =>
            _repository.GetAll().Where(chatUser => chatUser.UserId == userId).Select(chatUser => chatUser.Chat);
    }
}
