using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Prop.Api.Domain;
using Prop.Api.DTO;
using Prop.Api.Models;
using Prop.Api.Persistence;
using Prop.Api.Services;
using Prop.Api.Mapping;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------
// KONFIGURACJA BAZY DANYCH
// ---------------------------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PropDbContext>(options =>
    options.UseSqlServer(connectionString));

// ---------------------------------------------
// AUTO MAPPER
// ---------------------------------------------
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ---------------------------------------------
// SERWISY
// ---------------------------------------------
builder.Services.AddScoped<QuoteCalculator>();

// ---------------------------------------------
// JSON – wy³¹czenie cykli
// ---------------------------------------------
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// ---------------------------------------------
// SWAGGER
// ---------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ---------------------------------------------
// SWAGGER UI
// ---------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// ======================================================================
//  ENDPOINT POST /quotes
//  Tworzy: Client + Address + Quote
//  Zwraca: QuoteDto
// ======================================================================
app.MapPost("/quotes", async (
    CreateQuoteRequest request,
    PropDbContext dbContext,
    QuoteCalculator calculator,
    IMapper mapper,
    CancellationToken ct) =>
{
    // -----------------------------
    // Walidacja danych nieruchomoœci
    // -----------------------------
    if (request.PropertyArea <= 0)
        return Results.BadRequest("PropertyArea must be greater than 0.");

    if (request.PropertyYear < 1900)
        return Results.BadRequest("PropertyYear must be >= 1900.");

    // -----------------------------
    // Walidacja email
    // -----------------------------
    if (!string.IsNullOrWhiteSpace(request.ClientEmail))
    {
        if (request.ClientEmail.Length > 100)
            return Results.BadRequest("Email cannot exceed 100 characters.");

        if (!request.ClientEmail.Contains("@"))
            return Results.BadRequest("Invalid email format.");
    }

    // -----------------------------
    // Tworzenie klienta
    // -----------------------------
    var client = new Client
    {
        FirstName = request.ClientName,
        LastName = request.ClientLastName,
        Email = request.ClientEmail,
        Phone = request.ClientPhone
    };

    // -----------------------------
    // Tworzenie adresu klienta
    // -----------------------------
    var address = new Address
    {
        Street = request.Street,
        HomeNumber = request.HomeNumber,
        City = request.City,
        PostalCode = request.PostalCode,
        Country = request.Country,
        Client = client,
        PermanentResidence = request.PermanentResidence
    };

    // -----------------------------
    // Tworzenie oferty
    // -----------------------------
    var quote = new Quote
    {
        Client = client,
        PropertyArea = request.PropertyArea,
        PropertyYear = request.PropertyYear,
        HasSecuritySystem = request.HasSecuritySystem,
        RoomNumber = request.RoomNumber,
        ClaimNumber = request.ClaimNumber,
        Floor = request.Floor,
        TopFloor = request.TopFloor,
        FlammableFloor = request.FlammableFloor
    };

    quote.Premium = calculator.CalculatePremium(quote);

    // -----------------------------
    // Zapis do bazy
    // -----------------------------
    dbContext.Clients.Add(client);
    dbContext.Addresses.Add(address);
    dbContext.Quotes.Add(quote);

    await dbContext.SaveChangesAsync(ct);

    // -----------------------------
    // Mapowanie do DTO
    // -----------------------------
    var dto = mapper.Map<QuoteDto>(quote);

    return Results.Created($"/quotes/{quote.Id}", dto);
});


// ======================================================================
//  ENDPOINT GET /quotes/{id}
//  Zwraca: QuoteDto
// ======================================================================
app.MapGet("/quotes/{id:guid}", async (
    Guid id,
    PropDbContext dbContext,
    IMapper mapper,
    CancellationToken ct) =>
{
    var quote = await dbContext.Quotes
        .Include(q => q.Client)
        .ThenInclude(c => c.Address)
        .FirstOrDefaultAsync(q => q.Id == id, ct);

    if (quote is null)
        return Results.NotFound();

    var dto = mapper.Map<QuoteDto>(quote);

    return Results.Ok(dto);
});


// ---------------------------------------------
// START APLIKACJI
// ---------------------------------------------
app.Run();
