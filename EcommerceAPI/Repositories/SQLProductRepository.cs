using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Models.Domain;
using ECommerceAPI.Data;

namespace EcommerceAPI.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            var products = dbContext.Products.AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) 
            {
                if (filterOn.Contains("Name", StringComparison.OrdinalIgnoreCase))
                {
                    products = products.Where(x => x.ProductName.Contains(filterQuery));
                }
            }

            return await products.ToListAsync();
        }

        public async Task<Product?> GetByGuidAsync(Guid id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(Guid id, Product product)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.ShortDescription = product.ShortDescription;
            existingProduct.IsDiscontinued = product.IsDiscontinued;

            await dbContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == id);

            if (existingProduct == null)
            {
                return null;
            }

            dbContext.Products.Remove(existingProduct);
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}