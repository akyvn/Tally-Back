namespace Tally.Api.DTOs.Contacts;

public class CreateContactRequestDto
{
    public required string Name { get; set; }
    public string? AvatarUrl { get; set; }
}