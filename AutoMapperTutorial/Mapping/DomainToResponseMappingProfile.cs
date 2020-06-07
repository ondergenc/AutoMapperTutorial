using AutoMapper;
using AutoMapperTutorial.Contracts.v1.Responses;
using AutoMapperTutorial.Domain;

namespace AutoMapperTutorial.Mapping
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Product, ProductResponse>();
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderItem, OrderItemResponse>();
        }
    }
}
