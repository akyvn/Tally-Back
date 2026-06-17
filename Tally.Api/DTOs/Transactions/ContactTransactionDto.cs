using Tally.Api.DTOs.Contacts;

namespace Tally.Api.DTOs.Transactions;

public class ContactBalance
{
    public ContactDetailDto Contact { get; set; } = null!;
    public decimal Balance { get; set; }
}