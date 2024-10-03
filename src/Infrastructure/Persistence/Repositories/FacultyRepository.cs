using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class FacultyRepository : Repository<Faculty>, IFacultyRepository
{
    private readonly FlexBookDbContext _context;
    public FacultyRepository(FlexBookDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    public async Task<Guid> AddAsync(Faculty faculty)
    {
        await _context.AddAsync(faculty);
        return faculty.Id;
    }
}
