using Microsoft.EntityFrameworkCore;
using Tally.Api.Entities;

namespace Tally.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<TransactionContact> TransactionContacts => Set<TransactionContact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}