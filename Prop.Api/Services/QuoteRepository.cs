using Microsoft.EntityFrameworkCore;
using Prop.Api.Domain;
using Prop.Api.Persistence;

namespace Prop.Api.Services;

public class QuoteRepository
{
    private readonly PropDbContext _dbContext;

    public QuoteRepository(PropDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Quote> AddAsync(Quote quote, CancellationToken cancellationToken = default)
    {
        _dbContext.Quotes.Add(quote);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return quote;
    }

    public async Task<List<Quote>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Quotes
            .OrderByDescending(q => q.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Quote?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Quotes
            .FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }
}
