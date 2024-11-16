using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore; 

namespace ECommerceAPI;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { 
    }

    public DbSet<User> Users { get; set; }
}

