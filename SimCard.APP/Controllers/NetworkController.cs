
using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;

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
        public async Task<IActionResult> AddNetworks([FromBody] List<NetworkViewModel> networkViewModels)
        {
            foreach (var network in networkViewModels)
            {
                var existed = await _networkService.IsExisted(network.Ma, network.Ma.ToString());
                if (existed)
                {
                    await _networkService.Update(network);
                }
                else
                {
                    await _networkService.Create(network);
                }
            }
            
            return Ok();
        }
    }
}