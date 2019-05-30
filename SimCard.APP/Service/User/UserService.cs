using System.Threading.Tasks;

using AutoMapper;

using SimCard.APP.Helper;
using SimCard.APP.Models;
using SimCard.APP.Repository;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(UserViewModel userViewModel)
        {
            User user = Mapper.Map<User>(userViewModel);
            user.PasswordSalt = PasswordHelper.GetSalt();
            user.Password = PasswordHelper.HashPassword(user.Password, user.PasswordSalt);
            return await _repository.Create(user);
        }
    }
}
