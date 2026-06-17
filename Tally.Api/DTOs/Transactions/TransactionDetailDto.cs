namespace Tally.Api.DTOs.Transactions;

public class TransactionDetailDto
{
    public decimal Amount { get; set; }
    public string? Remarks { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
}