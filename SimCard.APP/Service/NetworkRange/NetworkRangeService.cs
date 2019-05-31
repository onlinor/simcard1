using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;
using SimCard.APP.Repository;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Service
{
    public class NetworkRangeService : INetworkRangeService
    {
        private readonly IRepository<NetworkRange> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public NetworkRangeService(IRepository<NetworkRange> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(NetworkRangeViewModel networkRangeViewModel)
        {
            // NetworkRange networkRange = Mapper.Map<NetworkRange>(networkRangeViewModel); should use one
            NetworkRange networkRange = new NetworkRange
            {
                Range_1 = networkRangeViewModel.Range_1,
                Range_2 = networkRangeViewModel.Range_2,
                Range_3 = networkRangeViewModel.Range_3,
                Range_4 = networkRangeViewModel.Range_4,
                Range_5 = networkRangeViewModel.Range_5,
                Range_6 = networkRangeViewModel.Range_6
            };

            await _repository.Create(networkRange);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<NetworkRangeViewModel> GetById(int id)
        {
            return Mapper.Map<NetworkRangeViewModel>(await _repository.GetById(id));
        }

        public async Task<IEnumerable<NetworkRangeViewModel>> GetAll()
        {
            return Mapper.Map<List<NetworkRangeViewModel>>(await _repository.GetAll());
        }

        public async Task<bool> Remove(int id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(NetworkRangeViewModel networkRangeViewModel)
        {
            NetworkRange NetworkRangeToUpdate = await _repository.Query(x => x.Id == networkRangeViewModel.Id).FirstOrDefaultAsync();

            NetworkRangeToUpdate.Range_1 = networkRangeViewModel.Range_1;
            NetworkRangeToUpdate.Range_2 = networkRangeViewModel.Range_2;
            NetworkRangeToUpdate.Range_3 = networkRangeViewModel.Range_3;
            NetworkRangeToUpdate.Range_4 = networkRangeViewModel.Range_4;
            NetworkRangeToUpdate.Range_5 = networkRangeViewModel.Range_5;
            NetworkRangeToUpdate.Range_6 = networkRangeViewModel.Range_6;

            await _repository.Update(NetworkRangeToUpdate);

            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
