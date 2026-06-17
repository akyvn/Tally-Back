using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tally.Api.Data;
using Tally.Api.DTOs.Contacts;
using Tally.Api.DTOs.Transactions;
using Tally.Api.Entities;

namespace Tally.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreateTransaction(CreateTransactionDto dto)
    {

        var contacts = await _context.Contacts
        .Where(x => dto.ContactIds.Contains(x.Id))
        .Select(x => new TransactionContact
        {
            ContactId = x.Id
        })
        .ToListAsync();

        var contactIds = dto.ContactIds.Distinct().ToList();

        if (contactIds.Count == 0)
            return BadRequest("At least one contact is required.");

        if (contacts.Count != contactIds.Count)
            return BadRequest("One or more contacts do not exist.");

        var transaction = new Transaction
        {
            Amount = dto.Amount,
            Remarks = dto.Remarks,
            TransactionDate = dto.TransactionDate,
            TransactionContacts = contacts
        };

        _context.Transactions.Add(transaction);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("GetAllContactsBalance")]
    public async Task<ActionResult<List<ContactBalance>>> GetAllContactsBalance()
    {
        var result  = await _context.Contacts
        .Select(x => new ContactBalance
        {
            Contact = new ContactDetailDto
            {
                Id = x.Id,
                Name = x.Name,
                AvatarUrl = x.AvatarUrl
            },
            Balance = x.TransactionContacts.Sum(tc => tc.Transaction.Amount / tc.Transaction.TransactionContacts.Count)
        })
        .OrderBy(x => x.Balance)
        .ToListAsync();

        return Ok(result);
    }

    [HttpGet("GetContactTransactions/{contactId:int}")]
    public async Task<ActionResult<List<TransactionDetailDto>>> GetContactTransactions(int contactId)
    {
        var contactTransactions = await _context.TransactionContacts
        .Where(x => x.ContactId == contactId)
        .OrderByDescending(x => x.Transaction.TransactionDate)
        .Select(x => new TransactionDetailDto
        {
            Amount = x.Transaction.Amount / x.Transaction.TransactionContacts.Count,
            Remarks = x.Transaction.Remarks,
            TransactionDate = x.Transaction.TransactionDate
        })
        .ToListAsync();

        return Ok(contactTransactions);
    }
}