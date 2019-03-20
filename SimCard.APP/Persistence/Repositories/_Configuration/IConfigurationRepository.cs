using SimCard.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public interface IConfigurationRepository
    {
        Task<IEnumerable<Configuration>> GetAllConfiguration();

        Task<Configuration> GetConfiguration(int id);

        Task<Configuration> UpdateConfiguration(int id, Configuration configuration);

    }
}