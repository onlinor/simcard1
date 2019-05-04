using AutoMapper;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shop, ShopViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Configuration, ConfigurationViewModel>().ReverseMap();
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Cashbook, CashbookViewModel>().ReverseMap();
            CreateMap<Bankbook, BankbookViewModel>().ReverseMap();
            CreateMap<ImportReceipt, ImportReceiptViewModel>().ReverseMap();
            CreateMap<ExportReceipt, ExportReceiptViewModel>().ReverseMap();
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<ProductExchange, ProductExchangeViewModel>().ReverseMap();
        }
    }
}