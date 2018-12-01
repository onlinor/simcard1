using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence.Repositories;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmailRepository emailRepository;
        public EmailController(IEmailRepository emailRepository, IMapper mapper)
        {
            this.emailRepository = emailRepository;
            this.mapper = mapper;
        }

        // api/email
        [HttpGet]
        public async Task<List<string>> GetAllEmail()
        {
            var dsEmail = await emailRepository.GetAllEmail();
            return dsEmail;
        }

        [HttpGet("eventactive")] 
        public async Task<List<Event>> GetListEventActive()
        {
            var dsEventActive = await emailRepository.GetListEventActive();
            return dsEventActive;
        }
    }
}