using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tally.Api.Data;
using Tally.Api.DTOs.Contacts;
using Tally.Api.Entities;

namespace Tally.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContactsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ContactDetailDto>>> GetContacts()
    {
        var contacts = await _context.Contacts
        .OrderBy(c => c.CreatedAt)
        .Select(c => new ContactDetailDto
        {
            Id = c.Id,
            Name = c.Name,
            AvatarUrl = c.AvatarUrl
        })
        .ToListAsync();

        return Ok(contacts);
    }

    [HttpPost]
    public async Task<ActionResult<ContactDetailDto>> CreateContact(CreateContactRequestDto dto)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            AvatarUrl = dto.AvatarUrl
        };

        _context.Contacts.Add(contact);

        await _context.SaveChangesAsync();

        var response = new ContactDetailDto
        {
            Id = contact.Id,
            Name = contact.Name,
            AvatarUrl = contact.AvatarUrl
        };

        return Ok(response);
    }
}