namespace Prop.Api.Domain;

public class Quote
{
    public Guid Id { get; set; }
    public string ClientName { get; set; } = default!;
    public string? ClientLastName { get; set; }
    public string ClientPhone { get; set; } = default!;
    public string Street { get; set; }
    public string HomeNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string? ClientEmail { get; set; }
    public decimal PropertyArea { get; set; }
    public int PropertyYear { get; set; }
    public bool HasSecuritySystem { get; set; }
    public decimal Premium { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

