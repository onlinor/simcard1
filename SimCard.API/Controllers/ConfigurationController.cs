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
    public class ConfigurationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConfigurationRepository configurationRepository;
        private readonly IUnitOfWork unitOfWork;

        public ConfigurationController(IConfigurationRepository configurationRepository, IUnitOfWork unitOfWork, IMapper mapper) {
            this.configurationRepository = configurationRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // api/configuration
        [HttpGet]
        public async Task<IEnumerable<ConfigurationResource>> GetAllConfiguration()
        {
            var configuration = await configurationRepository.GetAllConfiguration();
            return mapper.Map<IEnumerable<Configuration>, IEnumerable<ConfigurationResource>>(configuration);
        }

        // api/configuration/id
        [HttpGet("{id}")]
        public async Task<ConfigurationResource> GetConfiguration(int id)
        {
            var configuration = await configurationRepository.GetConfiguration(id);
            return mapper.Map<Configuration, ConfigurationResource>(configuration);
        }

        // api/customer 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfiguration(int id, Configuration configuration)
        {
            if (configuration == null)
            {
                return BadRequest();
            }
            await configurationRepository.UpdateConfiguration(id, configuration);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }
    }
}