namespace Prop.Api.DTO;

public class QuoteDto
{
    public Guid Id { get; set; }
    public decimal PropertyArea { get; set; }
    public int PropertyYear { get; set; }
    public bool HasSecuritySystem { get; set; }
    public decimal Premium { get; set; }

    public int RoomNumber { get; set; }
    public int ClaimNumber { get; set; }
    public int Floor { get; set; }
    public bool TopFloor { get; set; }
    public bool FlammableFloor { get; set; }
    public DateTime CreatedAt { get; set; }

    public ClientDto Client { get; set; } = default!;
}

