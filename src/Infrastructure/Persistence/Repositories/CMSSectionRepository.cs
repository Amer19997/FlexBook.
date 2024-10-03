using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class CMSSectionRepository : Repository<CMSSections>,ICMSSectionRepository
{
    private readonly FlexBookDbContext _context;
    public CMSSectionRepository(FlexBookDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<int> AddAsync(CMSSections section)
    {
        await _context.AddAsync(section);
        await _context.SaveChangesAsync();
        return section.Id;
    }
}
