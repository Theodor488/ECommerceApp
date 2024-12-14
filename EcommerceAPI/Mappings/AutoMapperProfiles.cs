using AutoMapper;
using EcommerceAPI.Models.Domain;
using EcommerceAPI.Models.DTO;

namespace EcommerceAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<AddCustomerRequestDTO, Customer>().ReverseMap();
            CreateMap<UpdateCustomerRequestDTO, Customer>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<AddOrderRequestDTO, Order>().ReverseMap();
            CreateMap<UpdateOrderRequestDTO, Order>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<AddProductRequestDTO, Product>().ReverseMap();
            CreateMap<UpdateProductRequestDTO, Product>().ReverseMap();
        }
    }
}
