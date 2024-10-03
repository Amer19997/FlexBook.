using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class CouresRepository :Repository<Course>, ICouresRepository
{
    public CouresRepository(FlexBookDbContext dbContext, IOptions<AppSettings> appSettings) : base(dbContext)
    {

    }
}
