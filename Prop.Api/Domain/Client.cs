using System.Net;

namespace Prop.Api.Domain;

public class Client
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    // Nawigacja 1:1 do adresu
    public Address? Address { get; set; }

    // Nawigacja 1:N do ofert
    public List<Quote> Quotes { get; set; } = new();
}

