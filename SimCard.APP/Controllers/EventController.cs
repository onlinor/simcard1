using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IEventRepository eventRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        // api/event
        [HttpGet]
        public async Task<IEnumerable<EventResource>> GetAllEvents()
        {
            IEnumerable<Event> events = await _eventRepository.GetAllEvents();
            return _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
        }

        // api/event/id
        [HttpGet("{id}")]
        public async Task<EventResource> GetEvent(int id)
        {
            Event eventParams = await _eventRepository.GetEvent(id);
            return _mapper.Map<Event, EventResource>(eventParams);
        }

        // api/event/last
        [HttpGet("last")]
        public async Task<int> GetLastIDEventRecord()
        {
            int lastIDRecord = await _eventRepository.GetLastIDEventRecord();
            return lastIDRecord;
        }

        // api/event/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            Event eventPrams = await _eventRepository.GetEvent(id);

            if (eventPrams == null)
            {
                return NotFound();
            }

            _eventRepository.Remove(eventPrams);
            await _unitOfWork.CompleteAsync();

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
            await _eventRepository.AddEvent(eventParams);
            await _unitOfWork.CompleteAsync();
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
            await _eventRepository.UpdateEvent(id, eventParams);
            await _unitOfWork.CompleteAsync();
            return StatusCode(201);
        }

        // api/event/status/id
        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateEventStatus(int id, Event eventParams)
        {
            if (eventParams == null)
            {
                return BadRequest();
            }
            await _eventRepository.UpdateEventStatus(id, eventParams);
            await _unitOfWork.CompleteAsync();
            return StatusCode(201);
        }
    }
}