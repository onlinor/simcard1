using SimCard.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public interface IEmailRepository
    {
        Task<List<string>> GetAllEmail();
        Task<List<Event>> GetListEventActive();
    }
}