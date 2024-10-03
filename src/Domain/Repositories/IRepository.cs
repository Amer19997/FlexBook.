using System.Linq.Expressions;
using X.PagedList;

namespace FlexBook.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> FindById(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<bool> IfExist(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task Add(TEntity entity, CancellationToken cancellationToken);
        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        
        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null,
                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                          int? skip = null,
                          int? take = null,
                          string includeProperties = "");
        Task<IPagedList<TEntity>> FindPagedList(Expression<Func<TEntity, bool>> filter = null,
                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                         int pageNumber = 1,
                         int pageSize = 10,
                         string includeProperties = "");
        Task<IPagedList<TEntity>> FindPagedList(IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                         int pageNumber = 1,
                         int pageSize = 10,
                         string includeProperties = "");
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);
        Task<int> CountAsync(IEnumerable<Expression<Func<TEntity, bool>>> filters);
    }
}
