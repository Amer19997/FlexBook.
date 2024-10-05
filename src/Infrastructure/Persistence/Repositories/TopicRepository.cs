using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities.Catalog;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Repositories;
using Microsoft.Extensions.Options;

namespace FlexBook.Infrastructure.Persistence.Repositories;

public class TopicRepository : Repository<Topic>, ITopicRepository
{
    public TopicRepository(FlexBookDbContext dbContext, IOptions<AppSettings> appSettings) : base(dbContext)
    {

    }
}
 