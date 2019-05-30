using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
{
    public interface INetworkRepository
    {
        Task<IEnumerable<Network>> GetNetworks();
        Task<Network> AddNetwork(Network Nw);
        void UpdateNetwork(Network Nw);
        void RemoveNetwork(Network Nw);
        //Task<bool> IsProductExists(Product pr);     
    }
}