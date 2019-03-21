using SimCard.APP.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IConfigurationRepository
    {
        Task<IEnumerable<Configuration>> GetAllConfiguration();

        Task<Configuration> GetConfiguration(int id);

        Task<Configuration> UpdateConfiguration(int id, Configuration configuration);

    }
}