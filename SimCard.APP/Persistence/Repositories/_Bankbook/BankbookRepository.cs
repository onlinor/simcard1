using Microsoft.EntityFrameworkCore;

using SimCard.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public class BankbookRepository : IBankbookRepository
    {
        private readonly SimCardDBContext _context;

        public BankbookRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<Bankbook> AddBankbook(Bankbook bankbookParams)
        {
            if (bankbookParams != null)
            {
                await _context.AddAsync(bankbookParams);
                await _context.SaveChangesAsync();
                return bankbookParams;
            }
            return null;
        }

        public async Task<IEnumerable<Bankbook>> GetAllBankbook()
        {
            return await _context.Bankbook.ToListAsync();
        }

        public async Task<Bankbook> GetBankbook(int id)
        {
            return await _context.Bankbook.FirstOrDefaultAsync(x => x.Id == id);
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
            _context.Remove(bankbookParams);
        }

        public async Task<Bankbook> UpdateBankbook(int id, Bankbook bankbookParams)
        {
            Bankbook bankbookToUpdate = _context.Bankbook.Find(id);
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
                _context.Bankbook.Update(bankbookToUpdate);
                await _context.SaveChangesAsync();
                return bankbookToUpdate;
            }
            return null;
        }
    }
}