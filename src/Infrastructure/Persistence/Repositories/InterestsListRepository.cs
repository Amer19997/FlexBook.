using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class InterestsListRepository:Repository<InterestsList> , IInterestsListRepository
{
    public InterestsListRepository(FlexBookDbContext dbContext, IOptions<AppSettings> appSettings) : base(dbContext)
    {

    }
}
