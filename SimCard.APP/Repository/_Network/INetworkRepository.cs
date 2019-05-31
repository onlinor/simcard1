using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public interface INetworkRepository
    {
        Task<Network> GetByCodeAsync(string code);   
    }
}