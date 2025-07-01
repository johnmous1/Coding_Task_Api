using AutoMapper;
using Coding_Task_Api.Domain.Aggregates;
using Coding_Task_Api.Application.Orders;
using Coding_Task_Api.Application.Customer;
using Coding_Task_Api.Application.Products;

namespace Coding_Task_Api.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(d => d.ItemCount, opt => opt.MapFrom(s => s.Items.Count));

            CreateMap<(UpdateCustomerRequest Request, Guid Id), UpdateCustomerCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Request.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Request.LastName))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Request.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Request.City))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Request.PostalCode));

            CreateMap<Product, ProductDto>();

        }
    }
}
