using AutoMapper;

using SimCard.APP.Controllers.Resources;
using SimCard.APP.Models;

namespace SimCard.APP.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shop, ShopResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<Customer, CustomerResource>();
            CreateMap<Configuration, ConfigurationResource>();
            CreateMap<Event, EventResource>();
            CreateMap<Cashbook, CashbookResource>();
            CreateMap<Bankbook, BankbookResource>();
            CreateMap<ImportReceipt, PhieunhapResource>();
        }
    }
}