using EcommerceAPI.Models.Domain;

namespace EcommerceAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByGuidAsync(Guid id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(Guid id, Customer customer);
        //Task<Customer?> DeleteAsync(Guid id);
    }
}