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
        }
    }
}
