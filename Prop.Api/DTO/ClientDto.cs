namespace Prop.Api.DTO;

public class ClientDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public AddressDto? Address { get; set; }
}

