using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;
        private readonly IUnitOfWork unitOfWork;
        public EventController(IEventRepository eventRepository, IMapper mapper, IUnitOfWork unitOfWork) {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        // api/event
        [HttpGet]
        public async Task<IEnumerable<EventResource>> GetAllEvents() 
        {
            var events = await eventRepository.GetAllEvents();
            return mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
        }

        // api/event/id
        [HttpGet("{id}")]
        public async Task<EventResource> GetEvent(int id) 
        {
            var eventParams = await eventRepository.GetEvent(id);
            return mapper.Map<Event, EventResource>(eventParams);
        }

        // api/event/last
        [HttpGet("last")]
        public async Task<int> GetLastIDEventRecord()
        {
            var lastIDRecord = await eventRepository.GetLastIDEventRecord();
            return lastIDRecord;
        }
        
        // api/event/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventPrams = await eventRepository.GetEvent(id);

            if (eventPrams == null)
                return NotFound();

            eventRepository.Remove(eventPrams);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        // api/event
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event eventParams)
        {
            if (eventParams == null)
            {
                return BadRequest();
            }
            await eventRepository.AddEvent(eventParams);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }

        // api/event/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event eventParams)
        {
            if (eventParams == null)
            {
                return BadRequest();
            }
            await eventRepository.UpdateEvent(id, eventParams);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }

        // api/event/status/id
        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateEventStatus(int id, Event eventParams)
        { 
            if (eventParams == null) {
                return BadRequest();
            }
            await eventRepository.UpdateEventStatus(id, eventParams);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }
    }
}