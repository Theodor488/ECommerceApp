using EcommerceAPI.Models.Domain;

namespace EcommerceAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByGuidAsync(Guid id);
        Task<Customer> CreateAsync(Order order);
        Task<Customer?> UpdateAsync(Guid id, Order order);
        Task<Customer?> DeleteAsync(Guid id);
    }
}