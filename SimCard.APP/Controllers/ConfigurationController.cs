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
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationController(IConfigurationRepository configurationRepository, IUnitOfWork unitOfWork)
        {
            _configurationRepository = configurationRepository;
            _unitOfWork = unitOfWork;
        }

        // api/configuration
        [HttpGet]
        public async Task<IEnumerable<ConfigurationViewModel>> GetAllConfiguration()
        {
            IEnumerable<Configuration> configuration = await _configurationRepository.GetAllConfiguration();
            return Mapper.Map<IEnumerable<Configuration>, IEnumerable<ConfigurationViewModel>>(configuration);
        }

        // api/configuration/id
        [HttpGet("{id}")]
        public async Task<ConfigurationViewModel> GetConfiguration(int id)
        {
            Configuration configuration = await _configurationRepository.GetConfiguration(id);
            return Mapper.Map<Configuration, ConfigurationViewModel>(configuration);
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
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }
    }
}