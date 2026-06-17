using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tally.Api.Entities;

namespace Tally.Api.Data.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(c => c.Remarks)
        .HasMaxLength(500);

        builder.Property(t => t.Amount)
        .HasPrecision(18, 2);
    }
}