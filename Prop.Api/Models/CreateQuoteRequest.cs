namespace Prop.Api.Models;

public class CreateQuoteRequest
{
    public string ClientName { get; set; } = default!;
    public string? ClientLastName { get; set; }
    public string? ClientEmail { get; set; }
    public string? ClientPhone { get; set; }

    public string? Street { get; set; }
    public string? HomeNumber { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public bool PermanentResidence { get; set; }

    public decimal PropertyArea { get; set; }
    public int PropertyYear { get; set; }
    public bool HasSecuritySystem { get; set; }
    public int RoomNumber { get; set; }
    public int ClaimNumber { get; set; }
    public int Floor { get; set; }
    public bool TopFloor { get; set; }
    public bool FlammableFloor { get; set; }
}