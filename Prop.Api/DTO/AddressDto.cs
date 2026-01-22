namespace Prop.Api.DTO;

public class AddressDto
{
    public Guid Id { get; set; }
    public string? Street { get; set; }
    public string? HomeNumber { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public bool PermanentResidence { get; set; }
}

