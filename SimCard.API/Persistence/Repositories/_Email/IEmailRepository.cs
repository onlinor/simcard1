using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public interface IEmailRepository
    {
        Task<List<string>> GetAllEmail();
        Task<List<Event>> GetListEventActive();
    }
}