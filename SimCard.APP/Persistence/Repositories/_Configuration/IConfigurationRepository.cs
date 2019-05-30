using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IConfigurationRepository
    {
        Task<IEnumerable<Configuration>> GetAllConfiguration();

        Task<Configuration> GetConfiguration(int id);

        Task<Configuration> UpdateConfiguration(int id, Configuration configuration);

    }
}