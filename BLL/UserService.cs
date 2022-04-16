using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Entities;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _useRepository;

        public UserService(IRepository<User> useRepository)
        {
            _useRepository = useRepository;
        }

        public void Delete(User entity) => _useRepository.Delete(entity);
       
        public User? Get(int userId) => _useRepository.Get(user => user.UserId == userId);
        public void Create(User user) => _useRepository.Create(user);
        public void Update(User entity) => _useRepository.Update(entity);

        public User? Get(string email) => _useRepository.GetAll().FirstOrDefault(user => user.Email == email);
    }
}
