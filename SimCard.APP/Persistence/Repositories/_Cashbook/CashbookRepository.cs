using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public class CashbookRepository : ICashbookRepository
    {
        private readonly SimCardDBContext context;
        public CashbookRepository(SimCardDBContext context)
        {
            this.context = context;
        }
        public async Task<Cashbook> AddCashbook(Cashbook cashbookParams)
        {
            if (cashbookParams != null)
            {
                await context.AddAsync(cashbookParams);
                await context.SaveChangesAsync();
                return cashbookParams;
            }
            return null;
        }

        public async Task<IEnumerable<Cashbook>> GetAllCashbook()
        {
            return await context.Cashbook.ToListAsync();
        }

        public async Task<Cashbook> GetCashbook(int id)
        {
            return await context.Cashbook.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Cashbook> Query(Expression<Func<Cashbook, bool>> predicate)
        {
            return context.Cashbook.Where(predicate);
        }

        // public async Task<int> GetLastIDCashbookRecord()
        // {
        //     return 1;
        //     // int lastIDRecord = 0;
        //     // var anyRecord = await context.Cashbook.AnyAsync();
        //     // if (anyRecord) {
        //     //     lastIDRecord = await context.Cashbook.MaxAsync(x => x.Id);
        //     // } 
        //     // return lastIDRecord;
        // }

        public void Remove(Cashbook cashbookParams)
        {
            context.Remove(cashbookParams);
        }

        public async Task<Cashbook> UpdateCashbook(int id, Cashbook cashbookParams)
        {
            var cashbookToUpdate = context.Cashbook.Find(id);
            if (cashbookParams != null)
            {
                cashbookToUpdate.NgayLap = cashbookParams.NgayLap;
                cashbookToUpdate.TenKhachHang = cashbookParams.TenKhachHang;
                cashbookToUpdate.MaKhachHang = cashbookParams.MaKhachHang;
                cashbookToUpdate.MaPhieu = cashbookParams.MaPhieu;
                cashbookToUpdate.NoiDungPhieu = cashbookParams.NoiDungPhieu;
                cashbookToUpdate.SoTienChi = cashbookParams.SoTienChi;
                cashbookToUpdate.SoTienThu = cashbookParams.SoTienThu;
                cashbookToUpdate.CongDon = cashbookParams.CongDon;
                cashbookToUpdate.DonViNhan = cashbookParams.DonViNhan;
                cashbookToUpdate.DonViNop = cashbookParams.DonViNop;
                cashbookToUpdate.HinhThucChi = cashbookParams.HinhThucChi;
                cashbookToUpdate.HinhThucNop = cashbookParams.HinhThucNop;
                cashbookToUpdate.NguoiChi = cashbookParams.NguoiChi;
                cashbookToUpdate.NguoiThu = cashbookParams.NguoiThu;
                cashbookToUpdate.GhiChu = cashbookParams.GhiChu;
                cashbookToUpdate.LoaiNganHang = cashbookParams.LoaiNganHang;
                context.Cashbook.Update(cashbookToUpdate);
                await context.SaveChangesAsync();
                return cashbookToUpdate;
            }
            return null;
        }
    }
}