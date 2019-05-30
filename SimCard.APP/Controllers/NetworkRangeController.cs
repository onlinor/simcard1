
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence.Services;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class NetworkRangeController : Controller
    {
        private readonly INetworkRangeService _networkRangeService;

        public NetworkRangeController(INetworkRangeService networkRangeService)
        {
            _networkRangeService = networkRangeService;
        }

        [HttpGet("/api/networkRange")]
        public async Task<IEnumerable<NetworkRangeViewModel>> GetNetworkRanges()
        {
            return await _networkRangeService.GetAll();
        }

        [HttpPost("/api/networkRange/add")]
        public async Task<IActionResult> AddNetworkRange(NetworkRangeViewModel networkRangeViewModel)
        {
            await _networkRangeService.Create(networkRangeViewModel);

            return Ok();
        }

        [HttpDelete("/api/networkRange/remove/{id}")]
        public async Task<IActionResult> RemoveNetworkRange(int id)
        {
            await _networkRangeService.Remove(id);

            return Ok();
        }

        [HttpPut("/api/networkRange/edit/{id}")]
        public async Task<IActionResult> EditNetworkRange(NetworkRangeViewModel productExchangeViewModel)
        {
            await _networkRangeService.Update(productExchangeViewModel);

            return Ok();
        }
    }
}