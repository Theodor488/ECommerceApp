using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Data;
using EcommerceAPI.Models.Domain;

namespace EcommerceAPI.Repositories
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLCustomerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            var customers = dbContext.Customers.Include("UserName").Include("First_Name").Include("Last_Name").AsQueryable();
            
            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) 
            {
                if (filterOn.Equals("UserName", StringComparison.OrdinalIgnoreCase))
                {
                    customers = customers.Where(x => x.UserName.Contains(filterQuery));
                }
            }

            return await customers.ToListAsync();
        }

        public async Task<Customer?> GetByGuidAsync(Guid id)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateAsync(Guid id, Customer customer)
        {
            var existingCustomer = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);

            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.UserName = customer.UserName;
            existingCustomer.First_Name = customer.First_Name;
            existingCustomer.Last_Name = customer.Last_Name;
            existingCustomer.Password = customer.Password;
            existingCustomer.Gender = customer.Gender;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;

            await dbContext.SaveChangesAsync();
            return existingCustomer;
        }

        public async Task<Customer?> DeleteAsync(Guid id)
        {
            var existingCustomer = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);

            if (existingCustomer == null)
            {
                return null;
            }

            dbContext.Customers.Remove(existingCustomer);
            await dbContext.SaveChangesAsync();
            return existingCustomer;
        }
    }
}