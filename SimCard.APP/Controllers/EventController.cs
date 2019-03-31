using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Models;
using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IEventRepository eventRepository, IUnitOfWork unitOfWork)
        {
            _eventRepository = eventRepository;
            _unitOfWork = unitOfWork;
        }
        // api/event
        [HttpGet]
        public async Task<IEnumerable<EventViewModel>> GetAllEvents()
        {
            IEnumerable<Event> events = await _eventRepository.GetAllEvents();
            return Mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);
        }

        // api/event/id
        [HttpGet("{id}")]
        public async Task<EventViewModel> GetEvent(int id)
        {
            Event eventParams = await _eventRepository.GetEvent(id);
            return Mapper.Map<Event, EventViewModel>(eventParams);
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
            await _unitOfWork.SaveChangeAsync();

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
            await _unitOfWork.SaveChangeAsync();
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
            await _unitOfWork.SaveChangeAsync();
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
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }
    }
}