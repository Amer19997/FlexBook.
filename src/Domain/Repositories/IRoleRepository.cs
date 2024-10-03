using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Repositories;
public interface IRoleRepository : IRepository<Role>
{
    Task<List<Role>> GetRols();
}
