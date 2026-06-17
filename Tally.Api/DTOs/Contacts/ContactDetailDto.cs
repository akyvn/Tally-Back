namespace Tally.Api.DTOs.Contacts;

public class ContactDetailDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? AvatarUrl { get; set; }
}