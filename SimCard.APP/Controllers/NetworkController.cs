
using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;
using SimCard.APP.Models;
using SimCard.APP.Persistence.Services;
using SimCard.APP.ViewModels;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddNetwork (NetworkViewModel networkViewModel)
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