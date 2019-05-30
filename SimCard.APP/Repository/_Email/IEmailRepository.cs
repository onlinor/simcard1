using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public interface IEmailRepository
    {
        Task<List<string>> GetAllEmail();

        Task<List<Event>> GetListEventActive();
    }
}