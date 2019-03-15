using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Phieunhap
{    
    public class PhieunhapRepository : IPhieunhapRepository
    {
        private readonly SimCardDBContext context;       

        public PhieunhapRepository(SimCardDBContext context)
        {
            this.context = context;
        }

        public async Task<Phieunhap> AddPhieunhap(Phieunhap phieunhap)
        {
            if (phieunhap != null)
            {
                await context.AddAsync(phieunhap);
                await context.SaveChangesAsync();
                return phieunhap;
            }
            return null;
        }

        public async Task<string> GenerateID()
        {
            var currentDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd").Replace("-", "");            
            // No data for new day
            var existingPNs = await context.Phieunhaps.Where(x => x.Prefixid.Replace("PN", "") == currentDate).ToListAsync();
            if (existingPNs.Count() == 0)  
            {
                return ("PN" + currentDate + ".1");
            }
            // Already Data in DB, genereated new suffix
            var newSuffix = existingPNs.Max(x => x.Suffixid) + 1;
            return ("PN" + currentDate + "." + newSuffix);
        }
    }
}