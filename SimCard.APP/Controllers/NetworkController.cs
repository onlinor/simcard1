
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Service;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class NetworkController : Controller
    {
        private readonly INetworkService _networkService;

        public NetworkController(INetworkService networkService)
        {
            _networkService = networkService;
        }

        [HttpGet("/api/network")]
        public async Task<IEnumerable<NetworkViewModel>> GetNetworks()
        {
            return await _networkService.GetAll();
        }

        [HttpPost("/api/network/add")]
        public async Task<IActionResult> AddNetwork(NetworkViewModel networkViewModel)
        {
            if (await _networkService.IsExisted(networkViewModel.Ma))
            {
                return BadRequest(networkViewModel.Ma + " already exists!");
            }
            await _networkService.Create(networkViewModel);

            return Ok();
        }

        [HttpDelete("/api/network/remove/{id}")]
        public async Task<IActionResult> RemoveNetwork(int id)
        {
            await _networkService.Remove(id);

            return Ok();
        }

        [HttpPut("/api/network/edit/{id}")]
        public async Task<IActionResult> EditNetwork(NetworkViewModel productExchangeViewModel)
        {
            await _networkService.Update(productExchangeViewModel);

            return Ok();
        }
    }
}