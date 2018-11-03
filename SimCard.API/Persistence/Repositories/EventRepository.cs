using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly SimCardDBContext context;

        public EventRepository(SimCardDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<Event> GetEvent(int id)
        {
            return await context.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Event> AddEvent(Event eventParams)
        {
            if (eventParams != null) {
                await context.AddAsync(eventParams);
                await context.SaveChangesAsync();
                return eventParams;
            }
            return null;
        }

        public async Task<Event> UpdateEvent(int id, Event eventParams)
        {
            var eventToUpdate = context.Events.Find(id);
            if (eventToUpdate != null) {
                eventToUpdate.LoaiSK = eventParams.LoaiSK;
                eventToUpdate.TenSK = eventParams.TenSK;
                eventToUpdate.NoiDung = eventParams.NoiDung;
                eventToUpdate.TgBatDau = eventParams.TgBatDau;
                eventToUpdate.TgKetThuc = eventParams.TgKetThuc;
                eventToUpdate.DoiTuong = eventParams.DoiTuong;
                context.Events.Update(eventToUpdate);
                await context.SaveChangesAsync();
                return eventToUpdate;
            }
            return null;
        }
        public async Task<int> GetLastIDEventRecord()
        {
            int lastIDRecord = await context.Events.MaxAsync(x => x.Id);
            return lastIDRecord;
        }
        
        public void Remove(Event eventParams)
        {
            context.Remove(eventParams);
        }

        public async Task<Event> UpdateEventStatus(int id, Event eventParams) {
            var eventToUpdate = context.Events.Find(id);
            if (eventParams != null) {
                eventToUpdate.EventStatus = eventParams.EventStatus;
                context.Events.Update(eventToUpdate);
                await context.SaveChangesAsync();
                return eventToUpdate;
            }
            return null;
        }

    }
}