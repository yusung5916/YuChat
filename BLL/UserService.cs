using System.Linq.Expressions;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Entities;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Create(User user) => _repository.Create(user);

        public void Update(User user) => _repository.Update(user);

        public void Delete(User user) => _repository.Delete(user);

        public User? Get(Expression<Func<User, bool>> predicate) => _repository.Get(predicate);
    }
}
