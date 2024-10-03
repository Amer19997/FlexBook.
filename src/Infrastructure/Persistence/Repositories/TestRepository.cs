using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class TestRepository : Repository<Test>, ITestRepository
{


    public TestRepository(FlexBookDbContext dbContext, IOptions<AppSettings> appSettings) : base(dbContext)
    {

    }
    public async Task<List<Test>> GetList()
    => await dbContext.Tests.ToListAsync();

}
