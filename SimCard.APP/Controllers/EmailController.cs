using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.API.Models;
using SimCard.API.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        // api/email
        [HttpGet]
        public async Task<List<string>> GetAllEmail()
        {
            List<string> dsEmail = await _emailRepository.GetAllEmail();
            return dsEmail;
        }

        [HttpGet("eventactive")]
        public async Task<List<Event>> GetListEventActive()
        {
            List<Event> dsEventActive = await _emailRepository.GetListEventActive();
            return dsEventActive;
        }
    }
}