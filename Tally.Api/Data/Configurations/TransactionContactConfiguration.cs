using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tally.Api.Entities;

namespace Tally.Api.Data.Configurations;

public class TransactionContactConfiguration : IEntityTypeConfiguration<TransactionContact>
{
    public void Configure(EntityTypeBuilder<TransactionContact> builder)
    {
        builder.HasKey(tc => new
        {
            tc.TransactionId,
            tc.ContactId
        });

        builder.HasOne(tc => tc.Transaction)
        .WithMany(t => t.TransactionContacts)
        .HasForeignKey(tc => tc.TransactionId);

        builder.HasOne(tc => tc.Contact)
        .WithMany(c => c.TransactionContacts)
        .HasForeignKey(tc => tc.ContactId);
    }
}