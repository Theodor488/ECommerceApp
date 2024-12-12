using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Models.Domain;
using ECommerceAPI.Data;

namespace EcommerceAPI.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLOrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetByGuidAsync(Guid id)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
        }

        public async Task<Order> CreateAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> UpdateAsync(Guid id, Order order)
        {
            var existingOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderID == id);

            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.IsCompleted = order.IsCompleted;
            existingOrder.Delivered = order.Delivered;
            existingOrder.CancelOrder = order.CancelOrder;

            await dbContext.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<Order?> DeleteAsync(Guid id)
        {
            var existingOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderID == id);

            if (existingOrder == null)
            {
                return null;
            }

            dbContext.Orders.Remove(existingOrder);
            await dbContext.SaveChangesAsync();
            return existingOrder;
        }
    }
}