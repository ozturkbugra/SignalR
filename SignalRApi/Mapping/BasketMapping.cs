using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BasketDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();

            CreateMap<Basket, ResultBasketWithProductAndTable>()
                       .ForMember(dest => dest.ProductName,
                                  opt => opt.MapFrom(src => src.Product.ProductName))
                       .ForMember(dest => dest.MenuTableName,
                                  opt => opt.MapFrom(src => src.MenuTable.Name));
        }
    }
}
