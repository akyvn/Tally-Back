namespace Tally.Api.Entities;

public class Contact : BaseEntity
{
    public required string Name { get; set; }
    public string? AvatarUrl { get; set; }
    public ICollection<TransactionContact> TransactionContacts { get; set; } = [];
}