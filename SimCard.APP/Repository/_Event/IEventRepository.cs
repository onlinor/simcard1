using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEvent(int id);

        Task<Event> AddEvent(Event eventParams);

        Task<Event> UpdateEvent(int id, Event eventParams);

        Task<int> GetLastIDEventRecord();

        Task<Event> UpdateEventStatus(int id, Event eventParams);

        List<Event> GetDSEvent();

        void Remove(Event eventParams);
    }
}