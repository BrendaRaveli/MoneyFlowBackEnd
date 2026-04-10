using Microsoft.EntityFrameworkCore;
using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Data;

public class MoneyFlowDbContext : DbContext
{
    public MoneyFlowDbContext(DbContextOptions<MoneyFlowDbContext> options)
     : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Category)
            .WithMany()
            .HasForeignKey(t => t.CategoryId);

        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasPrecision(18, 2);

        base.OnModelCreating(modelBuilder);
    }
}
