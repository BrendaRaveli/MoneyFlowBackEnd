using Microsoft.EntityFrameworkCore;
using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Data;

public class MoneyFlowDbContext : DbContext
{
    public MoneyFlowDbContext(DbContextOptions<MoneyFlowDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
}
