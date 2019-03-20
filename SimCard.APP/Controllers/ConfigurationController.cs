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
    public class ConfigurationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationController(IConfigurationRepository configurationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // api/configuration
        [HttpGet]
        public async Task<IEnumerable<ConfigurationResource>> GetAllConfiguration()
        {
            IEnumerable<Configuration> configuration = await _configurationRepository.GetAllConfiguration();
            return _mapper.Map<IEnumerable<Configuration>, IEnumerable<ConfigurationResource>>(configuration);
        }

        // api/configuration/id
        [HttpGet("{id}")]
        public async Task<ConfigurationResource> GetConfiguration(int id)
        {
            Configuration configuration = await _configurationRepository.GetConfiguration(id);
            return _mapper.Map<Configuration, ConfigurationResource>(configuration);
        }

        // api/customer 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfiguration(int id, Configuration configuration)
        {
            if (configuration == null)
            {
                return BadRequest();
            }
            await _configurationRepository.UpdateConfiguration(id, configuration);
            await _unitOfWork.CompleteAsync();
            return StatusCode(201);
        }
    }
}