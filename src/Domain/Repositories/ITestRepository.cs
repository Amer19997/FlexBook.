using FlexBook.Domain.Entities;

namespace FlexBook.Domain.Repositories;
public interface ITestRepository : IRepository<Test>
{
    Task<List<Test>> GetList();
}
