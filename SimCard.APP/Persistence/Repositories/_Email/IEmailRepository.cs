using SimCard.APP.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public interface IEmailRepository
    {
        Task<List<string>> GetAllEmail();

        Task<List<Event>> GetListEventActive();
    }
}