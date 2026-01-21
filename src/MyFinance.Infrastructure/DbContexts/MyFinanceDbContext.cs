using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;

namespace MyFinance.Infrastructure.DbContexts;

public class MyFinanceDbContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }

    public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).IsRequired();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Type).IsRequired();
            entity.HasOne(e => e.Category)
                  .WithMany(c => c.Transactions);
        });
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

        });
    }
}
