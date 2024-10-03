using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Repositories;
public interface IFacultyRepository:IRepository<Faculty>
{
    Task<Guid> AddAsync(Faculty faculty);
}
