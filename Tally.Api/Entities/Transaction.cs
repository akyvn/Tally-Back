namespace Tally.Api.Entities;

public class Transaction : BaseEntity
{
    public decimal Amount { get; set; }
    public string? Remarks { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public ICollection<TransactionContact> TransactionContacts { get; set; } = [];
}