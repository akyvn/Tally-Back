namespace Tally.Api.DTOs.Transactions;

public class CreateTransactionDto
{
    public decimal Amount { get; set; }
    public string? Remarks { get; set; }
    public DateTime TransactionDate { get; set; }
    public ICollection<int> ContactIds { get; set; } = [];

}