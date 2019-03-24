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
            CreateMap<ImportReceipt, ProductViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Configuration, ConfigurationViewModel>().ReverseMap();
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Cashbook, CashbookViewModel>().ReverseMap();
            CreateMap<Bankbook, BankbookViewModel>().ReverseMap();
            CreateMap<ImportReceipt, ImportReceiptViewModel>().ReverseMap();
            CreateMap<ExportReceipt, ExportReceiptViewModel>().ReverseMap();
        }
    }
}