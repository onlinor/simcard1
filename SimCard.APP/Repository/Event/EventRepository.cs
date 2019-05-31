using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly SimCardDBContext _context;

        public EventRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public List<Event> GetDSEvent()
        {
            return _context.Events.ToList();
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEvent(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Event> AddEvent(Event eventParams)
        {
            if (eventParams != null)
            {
                await _context.AddAsync(eventParams);
                await _context.SaveChangesAsync();
                return eventParams;
            }
            return null;
        }

        public async Task<Event> UpdateEvent(int id, Event eventParams)
        {
            var eventToUpdate = _context.Events.Find(id);
            if (eventToUpdate != null)
            {
                eventToUpdate.LoaiSK = eventParams.LoaiSK;
                eventToUpdate.TenSK = eventParams.TenSK;
                eventToUpdate.NoiDung = eventParams.NoiDung;
                eventToUpdate.TgBatDau = eventParams.TgBatDau;
                eventToUpdate.TgKetThuc = eventParams.TgKetThuc;
                eventToUpdate.DoiTuong = eventParams.DoiTuong;
                _context.Events.Update(eventToUpdate);
                await _context.SaveChangesAsync();
                return eventToUpdate;
            }
            return null;
        }
        public async Task<int> GetLastIDEventRecord()
        {
            var lastIDRecord = 0;
            var anyRecord = await _context.Events.AnyAsync();
            if (anyRecord)
            {
                lastIDRecord = await _context.Events.MaxAsync(x => x.Id);
            }
            return lastIDRecord;
        }

        public void Remove(Event eventParams)
        {
            _context.Remove(eventParams);
        }

        public async Task<Event> UpdateEventStatus(int id, Event eventParams)
        {
            var eventToUpdate = _context.Events.Find(id);
            if (eventParams != null)
            {
                eventToUpdate.EventStatus = eventParams.EventStatus;
                eventToUpdate.IsNewEvent = eventParams.IsNewEvent;
                eventToUpdate.IsCompleteEvent = eventParams.IsCompleteEvent;
                _context.Events.Update(eventToUpdate);
                await _context.SaveChangesAsync();
                return eventToUpdate;
            }
            return null;
        }

    }
}