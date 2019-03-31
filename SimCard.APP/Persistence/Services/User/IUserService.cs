using SimCard.APP.ViewModels;

using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public interface IUserService
    {
        Task<bool> Create(UserViewModel userViewModel);
    }
}
