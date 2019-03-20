using Microsoft.EntityFrameworkCore;

using SimCard.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly SimCardDBContext context;
        public ConfigurationRepository(SimCardDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Configuration>> GetAllConfiguration()
        {
            return await context.Configurations.ToListAsync();
        }

        public async Task<Configuration> GetConfiguration(int id)
        {
            return await context.Configurations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Configuration> UpdateConfiguration(int id, Configuration configuration)
        {
            Configuration configurationUpdate = context.Configurations.Find(id);
            if (configurationUpdate != null)
            {
                configurationUpdate.GiaTri = configuration.GiaTri;
                configurationUpdate.GhiChu = configuration.GhiChu;
                context.Configurations.Update(configurationUpdate);
                await context.SaveChangesAsync();
                return configurationUpdate;
            }
            return null;
        }
    }
}