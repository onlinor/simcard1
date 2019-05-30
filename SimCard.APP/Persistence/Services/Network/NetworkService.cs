using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

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
                MenhGia = networkViewModel.MenhGia,
                ChietKhauDauVao = networkViewModel.ChietKhauDauVao,
                ChietKhauCaoNhat = networkViewModel.ChietKhauCaoNhat,
                BuocNhay = networkViewModel.BuocNhay,
                KhungTien_1 = networkViewModel.KhungTien_1,
                KhungTien_2 = networkViewModel.KhungTien_2,
                KhungTien_3 = networkViewModel.KhungTien_3,
                KhungTien_4 = networkViewModel.KhungTien_4,
                KhungTien_5 = networkViewModel.KhungTien_5,
                KhungTien_6 = networkViewModel.KhungTien_6,
                KhungTien_7 = networkViewModel.KhungTien_7
            };

            await _repository.Create(network);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<NetworkViewModel> GetById(int id)
        {
            return Mapper.Map<NetworkViewModel>(await _repository.GetById(id));
        }

        public async Task<IEnumerable<NetworkViewModel>> GetAll()
        {
            return Mapper.Map<List<NetworkViewModel>>(await _repository.GetAll());
        }

        public async Task<bool> IsExisted(string code)
        {
            Network network = await _repository.Query(x => x.Ma.ToLower() == code.ToLower()).FirstOrDefaultAsync();
            return network != null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(NetworkViewModel networkViewModel)
        {
            Network NetworkToUpdate = await _repository.Query(x => x.Ma.ToLower() == networkViewModel.Ma.ToLower()).FirstOrDefaultAsync();

            NetworkToUpdate.ChietKhauCaoNhat = networkViewModel.ChietKhauCaoNhat;
            NetworkToUpdate.BuocNhay = networkViewModel.BuocNhay;
            NetworkToUpdate.KhungTien_1 = networkViewModel.ChietKhauCaoNhat;
            NetworkToUpdate.KhungTien_2 = NetworkToUpdate.KhungTien_1 - networkViewModel.BuocNhay;
            NetworkToUpdate.KhungTien_3 = NetworkToUpdate.KhungTien_2 - networkViewModel.BuocNhay;
            NetworkToUpdate.KhungTien_4 = NetworkToUpdate.KhungTien_3 - networkViewModel.BuocNhay;
            NetworkToUpdate.KhungTien_5 = NetworkToUpdate.KhungTien_4 - networkViewModel.BuocNhay;
            NetworkToUpdate.KhungTien_6 = NetworkToUpdate.KhungTien_5 - networkViewModel.BuocNhay;
            NetworkToUpdate.KhungTien_7 = NetworkToUpdate.KhungTien_6 - networkViewModel.BuocNhay;
            await _repository.Update(NetworkToUpdate);

            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
