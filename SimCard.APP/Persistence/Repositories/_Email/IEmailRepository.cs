using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IEmailRepository
    {
        Task<List<string>> GetAllEmail();

        Task<List<Event>> GetListEventActive();
    }
}