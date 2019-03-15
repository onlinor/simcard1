using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Phieunhap
{
    public interface IPhieunhapRepository
    {
        Task<string> GenerateID(); 
        Task<Phieunhap> AddPhieunhap(Phieunhap phieunhap);
    }
}