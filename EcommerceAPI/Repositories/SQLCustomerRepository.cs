using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Models.Domain;
using ECommerceAPI.Data;

namespace EcommerceAPI.Repositories
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLCustomerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByGuidAsync(Guid id)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
