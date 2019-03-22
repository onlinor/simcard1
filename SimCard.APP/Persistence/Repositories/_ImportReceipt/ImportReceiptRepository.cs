using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public class ImportReceiptRepository : IImportReceiptRepository
    {
        private readonly SimCardDBContext _context;

        public ImportReceiptRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<ImportReceipt> AddImportReceipt(ImportReceiptViewModel importReceiptViewModel)
        {
            if (importReceiptViewModel != null)
            {
                var importReceipt = Mapper.Map<ImportReceipt>(importReceiptViewModel);
                await _context.AddAsync(importReceipt);
                await _context.SaveChangesAsync();
                return importReceipt;
            }
            return null;
        }

        public async Task<string> GenerateID()
        {
            string currentDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd").Replace("-", "");
            // No data for new day
            List<ImportReceipt> existingPNs = await _context.ImportReceipts.Where(x => x.Prefix.Replace("PN", "") == currentDate).ToListAsync();
            if (existingPNs.Count() == 0)
            {
                return ("PN" + currentDate + ".1");
            }
            // Already Data in DB, genereated new suffix
            int newSuffix = existingPNs.Max(x => x.Suffix) + 1;
            return ("PN" + currentDate + "." + newSuffix);
        }

        public async Task<List<ExpandoObject>> GetImportSummary(List<ProductViewModel> productViewModels)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();

            // Where shop id != null => product of shop
            List<IGrouping<string, Product>> products = await _context.Products.Where(p => p.ShopId != null).GroupBy(p => p.Ma).ToListAsync();
            foreach (IGrouping<string, Product> item in products)
            {
                dynamic keyVal = new ExpandoObject();
                keyVal.Group = item.Key;
                keyVal.Items = Mapper.Map<List<ProductViewModel>>(item);
                result.Add(keyVal);
            }
            return result;
        }
    }
}