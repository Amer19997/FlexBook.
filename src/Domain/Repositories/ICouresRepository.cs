using FlexBook.Domain.Entities.LookUps;
using X.PagedList;

namespace FlexBook.Domain.Repositories;
public interface ICouresRepository:IRepository<Course>
{
    Task<List<Course>> GetCoursesWithFilterAsync(Guid? topicId, Guid? categoryId, string keyword, CancellationToken cancellationToken);
    Task<IPagedList<Course>> GetPaginatedCoursesWithFilterAsync(
    Guid? topicId,
    Guid? categoryId,
    string keyword,
    int pageNumber = 1,
    int pageSize = 10,
    string sortBy = "NameEn",
    string sortDirection = "asc",
    CancellationToken cancellationToken = default);
    Task<int> CountCoursesAsync(Guid? topicId, Guid? categoryId, string keyword, CancellationToken cancellationToken = default);

}
