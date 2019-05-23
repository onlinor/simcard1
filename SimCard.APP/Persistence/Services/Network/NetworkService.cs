using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;
using System;
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
            // Network NetworkToUpdate = await _repository.Query(x => x.Ma.ToLower() == networkViewModel.Ma.ToLower() && x.ShopId == networkViewModel.ShopId).FirstOrDefaultAsync();
            // if (NetworkToUpdate.ShopId == 1 && NetworkToUpdate.Soluong == 0)
            // {
            //     NetworkToUpdate.Soluong += networkViewModel.Soluong;
            //     NetworkToUpdate.DonGia = networkViewModel.DonGia;
            // }
            // else
            // {
            //     NetworkToUpdate.Soluong += networkViewModel.Soluong;
            //     if (NetworkToUpdate.ShopId != 1)
            //     {
            //         Network MainNetwork = await _repository.Query(x => x.Ma.ToLower() == networkViewModel.Ma.ToLower() && x.ShopId == 1).FirstOrDefaultAsync();
            //         MainNetwork.Soluong = MainNetwork.Soluong - networkViewModel.Soluong;
            //         await _repository.Update(MainNetwork);
            //     }
            // }
            // await _repository.Update(NetworkToUpdate);

            // return await _unitOfWork.SaveChangeAsync();
            throw new NotImplementedException();
        }
    }
}
