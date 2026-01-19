namespace Prop.Api.Models;

public class CreateQuoteRequest
{
    public string ClientName { get; set; } = default!;
    public string? ClientLastName { get; set; }
    public string? ClientEmail { get; set; }
    public string ClientPhone { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string HomeNumber { get; set; } = default!;
    public string City { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string Country { get; set; } = default!;
    public decimal PropertyArea { get; set; }
    public int PropertyYear { get; set; }
    public bool HasSecuritySystem { get; set; }
}
