namespace Prop.Api.Domain;

public class Address
{
    public Guid Id { get; set; }

    public string? Street { get; set; }
    public string? HomeNumber { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public bool PermanentResidence { get; set; }

    // Klucz obcy do klienta (1:1)
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = default!;
}

