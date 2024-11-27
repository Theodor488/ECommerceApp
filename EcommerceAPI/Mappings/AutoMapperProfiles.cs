using AutoMapper;
using EcommerceAPI.Models.Domain;
using ECommerceAPI.Models.DTO;

namespace EcommerceAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
