using System.Threading.Tasks;

using SimCard.APP.ViewModels;

namespace SimCard.APP.Persistence.Services
{
    public interface IUserService
    {
        Task<bool> Create(UserViewModel userViewModel);
    }
}
