namespace Tally.Api.Entities;

public class TransactionContact
{
    public int TransactionId { get; set; }
    public int ContactId { get; set; }
    public Transaction Transaction { get; set; } = null!;
    public Contact Contact { get; set; } = null!;
}