using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public class NetworkService : INetworkService
    {
        private readonly IRepository<Network> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public NetworkService(IRepository<Network> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(NetworkViewModel networkViewModel)
        {
            // Network network = Mapper.Map<Network>(networkViewModel); should use one
            Network network = new Network
            {
                Ten = networkViewModel.Ten,
                Ma = networkViewModel.Ma,
                Menhgia = networkViewModel.Menhgia,
                Soluong = networkViewModel.Soluong,
                DonGia = networkViewModel.DonGia,
                ShopId = networkViewModel.ShopId,
                Loai = networkViewModel.Loai,
                SupplierId = networkViewModel.SupplierId
            };

            if (network.ShopId != 1)
            {
                Network MainNetwork = await _repository.Query(x => x.Ma.ToLower() == networkViewModel.Ma.ToLower() && x.ShopId == 1).FirstOrDefaultAsync();
                MainNetwork.Soluong = MainNetwork.Soluong - networkViewModel.Soluong;
                await _repository.Update(MainNetwork);
            }
            await _repository.Create(network);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<NetworkViewModel> GetById(int id)
        {
            return Mapper.Map<NetworkViewModel>(await _repository.GetById(id));
        }

        public async Task<IEnumerable<NetworkViewModel>> GetAll()
        {
            return Mapper.Map<List<NetworkViewModel>>(await _repository.Query(x => x.ShopId == 1).ToListAsync());
        }

        public async Task<bool> IsExisted(string code, int? shopId)
        {
            Network network = await _repository.Query(x => x.Ma.ToLower() == code.ToLower() && x.ShopId == shopId).FirstOrDefaultAsync();
            return network != null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(NetworkViewModel networkViewModel)
        {
            Network NetworkToUpdate = await _repository.Query(x => x.Ma.ToLower() == networkViewModel.Ma.ToLower() && x.ShopId == networkViewModel.ShopId).FirstOrDefaultAsync();
            if (NetworkToUpdate.ShopId == 1 && NetworkToUpdate.Soluong == 0)
            {
                NetworkToUpdate.Soluong += networkViewModel.Soluong;
                NetworkToUpdate.DonGia = networkViewModel.DonGia;
            }
            else
            {
                NetworkToUpdate.Soluong += networkViewModel.Soluong;
                if (NetworkToUpdate.ShopId != 1)
                {
                    Network MainNetwork = await _repository.Query(x => x.Ma.ToLower() == networkViewModel.Ma.ToLower() && x.ShopId == 1).FirstOrDefaultAsync();
                    MainNetwork.Soluong = MainNetwork.Soluong - networkViewModel.Soluong;
                    await _repository.Update(MainNetwork);
                }
            }
            await _repository.Update(NetworkToUpdate);

            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
