
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public interface INetworkService
    {
        Task<IEnumerable<NetworkViewModel>> GetAll();

        Task<NetworkViewModel> GetById(int id);

        Task<bool> Create(NetworkViewModel networkViewModels);

        Task<bool> Update(NetworkViewModel networkViewModel);

        Task<bool> Remove(int id);

        Task<bool> IsExisted(string code, int? shopId);
    }
}
