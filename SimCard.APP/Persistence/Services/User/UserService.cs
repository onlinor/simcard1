using AutoMapper;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
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
