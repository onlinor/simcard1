
using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
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