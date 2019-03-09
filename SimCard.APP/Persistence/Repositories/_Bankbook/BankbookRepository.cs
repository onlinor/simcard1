using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public class BankbookRepository : IBankbookRepository
    {
        private readonly SimCardDBContext context;
        public BankbookRepository(SimCardDBContext context)
        {
            this.context = context;
        }

        public async Task<Bankbook> AddBankbook(Bankbook bankbookParams)
        {
            if (bankbookParams != null)
            {
                await context.AddAsync(bankbookParams);
                await context.SaveChangesAsync();
                return bankbookParams;
            }
            return null;
        }

        public async Task<IEnumerable<Bankbook>> GetAllBankbook()
        {
            return await context.Bankbook.ToListAsync();
        }

        public async Task<Bankbook> GetBankbook(int id)
        {
             return await context.Bankbook.FirstOrDefaultAsync(x => x.Id == id);
        }

        // public async Task<int> GetLastIDBankbookRecord()
        // {
        //     return 1;
        //     // int lastIDRecord = 0;
        //     // var anyRecord = await context.Bankbook.AnyAsync();
        //     // if (anyRecord) {
        //     //     lastIDRecord = await context.Bankbook.MaxAsync(x => x.Id);
        //     // } 
        //     // return lastIDRecord;
        // }

        public void Remove(Bankbook bankbookParams)
        {
            context.Remove(bankbookParams);
        }

        public async Task<Bankbook> UpdateBankbook(int id, Bankbook bankbookParams)
        {
            var bankbookToUpdate = context.Bankbook.Find(id);
            if (bankbookParams != null)
            {
                bankbookToUpdate.NgayLap = bankbookParams.NgayLap;
                bankbookToUpdate.TenKhachHang = bankbookParams.TenKhachHang;
                bankbookToUpdate.MaKhachHang = bankbookParams.MaKhachHang;
                bankbookToUpdate.MaPhieu = bankbookParams.MaPhieu;
                bankbookToUpdate.NoiDungPhieu = bankbookParams.NoiDungPhieu;
                bankbookToUpdate.SoTienChi = bankbookParams.SoTienChi;
                bankbookToUpdate.SoTienThu = bankbookParams.SoTienThu;
                bankbookToUpdate.CongDon = bankbookParams.CongDon;
                bankbookToUpdate.DonViNhan = bankbookParams.DonViNhan;
                bankbookToUpdate.DonViNop = bankbookParams.DonViNop;
                bankbookToUpdate.HinhThucChi = bankbookParams.HinhThucChi;
                bankbookToUpdate.HinhThucNop = bankbookParams.HinhThucNop;
                bankbookToUpdate.NguoiChi = bankbookParams.NguoiChi;
                bankbookToUpdate.NguoiThu = bankbookParams.NguoiThu;
                bankbookToUpdate.GhiChu = bankbookParams.GhiChu;
                bankbookToUpdate.LoaiNganHang = bankbookParams.LoaiNganHang;
                context.Bankbook.Update(bankbookToUpdate);
                await context.SaveChangesAsync();
                return bankbookToUpdate;
            }
            return null;
        }
    }
}