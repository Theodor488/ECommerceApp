using EcommerceAPI.Models.Domain;

namespace EcommerceAPI.Repositories
{
    public class ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
    }
}
