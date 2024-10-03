using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Repositories;
public interface ICMSSectionRepository:IRepository<CMSSections>
{
    Task<int> AddAsync(CMSSections section);
}
