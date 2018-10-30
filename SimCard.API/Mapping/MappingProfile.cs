using AutoMapper;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;

namespace SimCard.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shop, ShopResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<Customer, CustomerResource>();
            CreateMap<Configuration, ConfigurationResource>();
        }
    }
}