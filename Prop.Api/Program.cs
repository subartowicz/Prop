using Microsoft.EntityFrameworkCore;
using Prop.Api.Domain;
using Prop.Api.Models;
using Prop.Api.Persistence;
using Prop.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Wczytanie connection stringa
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Rejestracja DbContext z SQL Server (LocalDB)
builder.Services.AddDbContext<PropDbContext>(options =>
    options.UseSqlServer(connectionString));

// Rejestracja serwisów
builder.Services.AddScoped<QuoteRepository>();
builder.Services.AddScoped<QuoteCalculator>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger tylko w Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint POST /quotes
app.MapPost("/quotes", async (CreateQuoteRequest request, QuoteRepository repo, QuoteCalculator calculator, CancellationToken ct) =>
{
    // Walidacja danych nieruchomoœci
    if (request.PropertyArea <= 0 || request.PropertyYear < 1900)
    {
        return Results.BadRequest("Invalid property data.");
    }

    // Walidacja emaila (opcjonalny)
    if (!string.IsNullOrWhiteSpace(request.ClientEmail))
    {
        if (request.ClientEmail.Length > 50)
            return Results.BadRequest("Email cannot exceed 50 characters.");

        if (!request.ClientEmail.Contains("@"))
            return Results.BadRequest("Invalid email format. Email must contain '@'.");
    }

    var quote = new Quote
    {
        ClientName = request.ClientName,
        ClientLastName = request.ClientLastName,
        ClientEmail = request.ClientEmail,
        ClientPhone = request.ClientPhone,
        Street = request.Street,
        HomeNumber = request.HomeNumber,
        City = request.City,
        PostalCode = request.PostalCode,
        Country = request.Country,
        PropertyArea = request.PropertyArea,
        PropertyYear = request.PropertyYear,
        HasSecuritySystem = request.HasSecuritySystem
    };

    quote.Premium = calculator.CalculatePremium(quote);
    await repo.AddAsync(quote, ct);

    return Results.Created($"/quotes/{quote.Id}", quote);
});

// Endpoint GET /quotes
app.MapGet("/quotes", async (QuoteRepository repo, CancellationToken ct) =>
{
    var quotes = await repo.GetAllAsync(ct);
    return Results.Ok(quotes);
});

// Endpoint GET /quotes/{id}
app.MapGet("/quotes/{id:guid}", async (Guid id, QuoteRepository repo, CancellationToken ct) =>
{
    var quote = await repo.GetByIdAsync(id, ct);
    return quote is null ? Results.NotFound() : Results.Ok(quote);
});

app.Run();
