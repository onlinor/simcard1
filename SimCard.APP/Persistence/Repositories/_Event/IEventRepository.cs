using SimCard.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEvent(int id);

        Task<Event> AddEvent(Event eventParams);

        Task<Event> UpdateEvent(int id, Event eventParams);

        Task<int> GetLastIDEventRecord();

        Task<Event> UpdateEventStatus(int id, Event eventParams);

        List<Event> getDSEvent();

        void Remove(Event eventParams);
    }
}